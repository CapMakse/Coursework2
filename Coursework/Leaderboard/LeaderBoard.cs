using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace Coursework.Leaderboard
{
    class LeaderBoard 
    {
        private static readonly LeaderBoard Instance = new LeaderBoard();
        private readonly SqlConnection Connection;
        private LeaderBoard()
        {
            string ConnectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Records;Integrated Security=True";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public static LeaderBoard GetInstance()
        {
            return Instance;
        }
        public void SaveRecord(string Name, string Weapon, string Target, int Score, int Distance)
        {
            string SQLExpression = String.Format("INSERT INTO Records VALUES (@Name, '{0}', '{1}', {2}, {3})", Weapon, Target, Score, Distance);
            SqlParameter NamePar = new SqlParameter("@Name", Name);
            SqlCommand Command = new SqlCommand(SQLExpression, Connection);
            Command.Parameters.Add(NamePar);
            Command.ExecuteNonQuery();
        }
        public void LoadRecord()
        {
            string SQLExpression = "SELECT * FROM Records ORDER BY Score DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(SQLExpression, Connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            var Records = from rec in ds.Tables[0].AsEnumerable()
                    select new { Name = rec["Name"], Weapon = rec["Weapon"], Target = rec["Target"], Score = rec["Score"], Distance = rec["Distance"] };
            Console.WriteLine("Введите имя игрока результаты которого хотите посмотреть.\n(ничего не вводите если хотите посмотреть все результаты)");
            string Name = Console.ReadLine();
            if (Name != "") Records = Records.Where(Record => Record.Name.ToString() == Name);
            Console.WriteLine("Введите число результатов которое хотите видеть.");
            if (!(Int32.TryParse(Console.ReadLine(), out int Count) && Count > 0)) Count = 100;
            foreach (var Record in Records.Take(Count))
                Console.WriteLine("Игрок {0} стреляя по мишени \"{1}\" из оружия \"{2}\", набрал {3} очков с растояния {4} м.", Record.Name, Record.Target, Record.Weapon, Record.Score, Record.Distance);
        }
    }
}
