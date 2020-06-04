using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Weapons
{
    abstract class Weapon
    {
        protected double Radius;
        protected double BulletEnergy;
        public void GetHitCoordinates(ref double X, ref double Y, int Distance)
        {
            WeaponScatter(ref X, ref Y, Distance);
            BulletBallistics(ref Y, Distance);
        }
        protected void WeaponScatter(ref double X, ref double Y, int Distance)
        {
            Random rnd = new Random();
            double NewRadius = rnd.NextDouble() * Radius * Distance;
            double NewAngle = rnd.NextDouble() * 2 * Math.PI;
            X += NewRadius * Math.Cos(NewAngle);
            Y += NewRadius * Math.Sin(NewAngle);
        }
        protected void BulletBallistics(ref double Y, int Distance)
        {
            Y -= Math.Pow((Distance / BulletEnergy), 3);
        }
        public abstract string GetTypeName();
    }
}
