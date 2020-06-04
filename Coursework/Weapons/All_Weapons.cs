using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Weapons
{
    class Pistol : Weapon
    {
        public Pistol() { Radius = 0.75; BulletEnergy = 50; TypeName = "Пистолет"; }
    }
    class AssaultRifle : Weapon
    {
        public AssaultRifle() { Radius = 0.5; BulletEnergy = 150; TypeName = "Автомат"; }
    }
    class SniperRifle : Weapon
    {
        public SniperRifle() { Radius = 0.1; BulletEnergy = 300; TypeName = "Снайперская винтовка"; }
    }
}
