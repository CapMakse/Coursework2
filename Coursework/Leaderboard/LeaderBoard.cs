using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace Coursework.Leaderboard
{
    /// <summary>
    /// Класс таблицы лидеров
    /// </summary>
    class LeaderBoard 
    {
        private static readonly LeaderBoard Instance = new LeaderBoard();
        private readonly XDocument RecordsDoc;
        private LeaderBoard()
        {
            if (File.Exists("Records.xml")) RecordsDoc = XDocument.Load("Records.xml");
            else RecordsDoc = new XDocument(new XElement("Records"));
        }
        /// <summary>
        /// Возвращает единственный екземпляр класса
        /// </summary>
        /// <returns>Екземпляр класса</returns>
        public static LeaderBoard GetInstance()
        {
            return Instance;
        }
        /// <summary>
        /// Сохраняет рекорд
        /// </summary>
        /// <param name="Name">Имя игрока</param>
        /// <param name="Weapon">Тип оружия</param>
        /// <param name="Target">Тип мишени</param>
        /// <param name="Score">Количество очков</param>
        /// <param name="Distance">Растояние до мишени</param>
        public void SaveRecord(string Name, string Weapon, string Target, int Score, int Distance)
        {
            XElement Record = new XElement("Record",
                new XAttribute("Name", Name),
                new XAttribute("Weapon", Weapon),
                new XAttribute("Target", Target),
                new XAttribute("Score", Score),
                new XAttribute("Distance", Distance));
            RecordsDoc.Root.Add(Record);
            RecordsDoc.Save("Records.xml");
        }
        /// <summary>
        /// Выводит на консоль таблицу рекордов
        /// </summary>
        public void LoadRecord()
        {
           var Records = from rec in RecordsDoc.Descendants("Record")
                         select new { Name = rec.Attribute("Name").Value, Weapon = rec.Attribute("Weapon").Value, Target = rec.Attribute("Target").Value, Score = rec.Attribute("Score").Value, Distance = rec.Attribute("Distance").Value };
            Console.WriteLine("Введите имя игрока результаты которого хотите посмотреть.\n(ничего не вводите если хотите посмотреть результаты всех игроков)");
            string Name = Console.ReadLine();
            if (Name != "") Records = Records.Where(Record => Record.Name.ToString() == Name);
            Console.WriteLine("Введите число результатов которое хотите видеть. (По умолчанию 10)");
            if (!(Int32.TryParse(Console.ReadLine(), out int Count) && Count > 0)) Count = 10;
            foreach (var Record in Records.Take(Count))
                Console.WriteLine("Игрок {0} стреляя по мишени \"{1}\" из оружия \"{2}\", набрал {3} очков с растояния {4} м.", Record.Name, Record.Target, Record.Weapon, Record.Score, Record.Distance);
            Console.WriteLine("Что-бы продожить нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
