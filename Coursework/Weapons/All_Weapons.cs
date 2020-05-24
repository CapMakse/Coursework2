using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Weapons
{
    class Pistol : Weapon
    {
        public Pistol() { Radius = 0.35; BulletEnergy = 50; }
    }
    class AssaultRifle : Weapon
    {
        public AssaultRifle() { Radius = 0.2; BulletEnergy = 150; }
    }
    class SniperRifle : Weapon
    {
        public SniperRifle() { Radius = 0.05; BulletEnergy = 300; }
    }
}
