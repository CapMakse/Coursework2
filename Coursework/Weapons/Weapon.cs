using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Weapons
{
    abstract class Weapon
    {
        protected double Radius;
        protected double BulletEnergy;
        public void HitCoordinates(ref double X, ref double Y, double Distance)
        {
            WeaponScatter(ref X, ref Y, Distance);
            BulletBallistics(ref X, Distance);
        }
        protected void WeaponScatter(ref double X, ref double Y, double Distance)
        {
            Random rnd = new Random();
            double NewRadius = rnd.NextDouble() * Radius * Distance;
            double NewAngle = rnd.NextDouble() * 2 * Math.PI;
            X += NewRadius * Math.Cos(NewAngle);
            Y += NewRadius * Math.Sin(NewAngle);
        }
        protected void BulletBallistics(ref double X, double Distance)
        {
            X -= Math.Pow((Distance / BulletEnergy), 3);
        }
    }
}
