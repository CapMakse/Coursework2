using Coursework.Targets;
using Coursework.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework
{
    class Rifleman
    {
        private WeaponContext Weapon = new WeaponContext();
        private TargetContext Target = new TargetContext();
        private double X, Y, Distance;
        public bool MakeChoice() 
        {
            string Choice;
            Console.WriteLine("Что вы желаете сделать?");
            Console.WriteLine("Сменить оружие, сменить мишень, выбрать растояние до мишени, выстрелить или закончить");
            while (true)
            {
                Choice = Console.ReadLine().ToLower().Trim(' ');
                if (Choice == "закончить") { return false; }
                else if (Choice == "выстрелить") { Shoot(); break; }
                else if(Choice == "выбрать растояние до мишени" || Choice == "выбрать растояние") { SetDistance(); break; }
                else if (Choice == "сменить оружие") { SetWeapon(); break; }
                else if (Choice == "сменить мишень") { SetTarget(); break; }
                else Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
            return true;
        }
        private void SetWeapon()
        {
            string Weap;
            Console.WriteLine("Выберите тип оружия которое хотите использовать. (пистолет, автомат или снайперская винтовка)");
            while (true)
            {
                Weap = Console.ReadLine().ToLower().Trim(' ');
                if (Weap == "пистолет") { Weapon.SetWeapon(new Pistol()); break; }
                else if (Weap == "автомат") { Weapon.SetWeapon(new AssaultRifle()); break; }
                else if (Weap == "снайперская винтовка") { Weapon.SetWeapon(new SniperRifle()); break; }
                else Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
        }
        private void SetTarget()
        {
            string Trg;
            Console.WriteLine("Выберите мишень по кторой будете стрелять. (круглая или человек)");
            while (true)
            {
                Trg = Console.ReadLine().ToLower().Trim(' ');
                if (Trg == "круглая") { Target.SetTarget(new RoundTarget()); break; }
                else if (Trg == "человек") { Target.SetTarget(new HumanTarget()); break; }
                else Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
        }
        private void SetDistance()
        {
            string Dis;
            Console.WriteLine("Введите на какое растояние отойти");
            while (true)
            {
                Dis = Console.ReadLine();
                if (double.TryParse(Dis, out Distance)) { if (Distance > 0) { break; } }
                Console.WriteLine("Вы ввели неправильно. Попробуйте снова.");
            }
        }
        private void Shoot()
        {

        }
    }
}
