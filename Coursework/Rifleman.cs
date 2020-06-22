using Coursework.Leaderboard;
using Coursework.Targets;
using Coursework.Weapons;
using System;

namespace Coursework
{
    /// <summary>
    /// Класс стрелка
    /// </summary>
    class Rifleman
    {
        private readonly LeaderBoard Board = LeaderBoard.GetInstance();
        private readonly DrawTarget Drawer = DrawTarget.GetInstance();
        private readonly TargetContext Target = new TargetContext();
        private Weapon Weapon;
        private int Distance = 1;
        /// <summary>
        /// Запустить игру
        /// </summary>
        public void Play()
        {
            while (MakeChoice()) { }
        }
        /// <summary>
        /// Выбрать что игрок будет делать
        /// </summary>
        /// <returns>Возвращает false если игрок решил завершить игру, иначе true</returns>
        private bool MakeChoice() 
        {
            string Choice;
            Console.WriteLine("Что вы желаете сделать?");
            Console.WriteLine("1 - Сменить оружие\n2 - Сменить мишень\n3 - Выбрать растояние до мишени\n4 - Стрелять\n5 - Посмотреть таблицу лидеров\n6 - Закончить");
            while (true)
            {
                Choice = Console.ReadLine();
                if (Choice == "6") { return false; }
                else if (Choice == "5") { Board.LoadRecord(); break; }
                else if (Choice == "4") { Shoot(); break; }
                else if (Choice == "3") { SetDistance(); break; }
                else if (Choice == "2") { SetTarget(); break; }
                else if (Choice == "1") { SetWeapon(); break; }
                else Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
            return true;
        }
        /// <summary>
        /// Выбрать оружие
        /// </summary>
        private void SetWeapon()
        {
            string Weap;
            Console.WriteLine("Выберите тип оружия которое хотите использовать.");
            Console.WriteLine("1 - Пистолет\n2 - Автомат\n3 - Снайперская винтовка");
            while (true)
            {
                Weap = Console.ReadLine();
                if (Weap == "1") { WeaponFactory PistolFactory = new PistolFactory(); Weapon = PistolFactory.GetWeapon(); break; }
                else if (Weap == "2") { WeaponFactory AsRifFact = new AssaultRifleFactory(); Weapon = AsRifFact.GetWeapon(); break; }
                else if (Weap == "3") { WeaponFactory SnipRifFact = new SniperRifleFactory(); Weapon = SnipRifFact.GetWeapon(); break; }
                else Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
        }
        /// <summary>
        /// Выбрать мишень
        /// </summary>
        private void SetTarget()
        {
            string Trg;
            Console.WriteLine("Выберите мишень по кторой будете стрелять.");
            Console.WriteLine("1 - Круглая\n2 - Человек");
            while (true)
            {
                Trg = Console.ReadLine();
                if (Trg == "1") { Target.SetTarget(new RoundTarget()); break; }
                else if (Trg == "2") { Target.SetTarget(new HumanTarget()); break; }
                else Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
        }
        /// <summary>
        /// Выбрать растояние до мишени
        /// </summary>
        private void SetDistance()
        {
            Console.WriteLine("Введите на какое растояние отойти");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out Distance)) { if (Distance > 0) { break; } }
                Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
        }
        /// <summary>
        /// Начать стрельбу
        /// </summary>
        private void Shoot()
        {
            if (Weapon == null || Target.CheckLackTarget())
            {
                Console.WriteLine("Сначала выберите оружие/мишень/растояние.");
                return;
            }
            double X, Y;
            int Score = 0;
            Console.Clear();
            Drawer.Draw(Target.GetTypeName() + ".jpg");
            for (int Shot = 1; Shot < 11; Shot++)
            {
                while (true)
                {
                    Console.WriteLine("Введите координату X, потом координату Y.");
                    if (double.TryParse(Console.ReadLine(), out X) && double.TryParse(Console.ReadLine(), out Y)) { break; }
                    Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
                }
                Weapon.GetHitCoordinates(ref X, ref Y, Distance);
                int ShotScore = Target.GetScore(X, Y);
                Score += ShotScore;
                Console.WriteLine("Количество очков за {0} выстрел: {1}", Shot, ShotScore);
                Console.WriteLine("Вы попали в X: {0}, Y: {1}", Math.Round(X, 2), Math.Round(Y, 2));
            }
            Console.WriteLine("Всего вы набрали {0} очков", Score);
            Console.WriteLine("Желаете сохранить результат? 1 - Да");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Введите имя стрелка");
                Board.SaveRecord(Console.ReadLine(), Weapon.GetTypeName(), Target.GetTypeName(), Score, Distance);
            }
            Console.Clear();
        }
    }
}
