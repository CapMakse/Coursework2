using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Weapons
{
    class Pistol : Weapon
    {
        public Pistol() { Radius = 0.75; BulletEnergy = 50; }
        public override string GetTypeName()
        {
            return "Пистолет";
        }
    }
    class AssaultRifle : Weapon
    {
        public AssaultRifle() { Radius = 0.5; BulletEnergy = 150; }
        public override string GetTypeName()
        {
            return "Автомат";
        }
    }
    class SniperRifle : Weapon
    {
        public SniperRifle() { Radius = 0.1; BulletEnergy = 300; }
        public override string GetTypeName()
        {
            return "Снайперская винтовка";
        }
    }
}
