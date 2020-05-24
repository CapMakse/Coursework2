using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Coursework.Weapons
{
    class WeaponContext
    {
        private Weapon Weap;
        public void SetWeapon(Weapon Weap)
        {
            this.Weap = Weap;
        }
        public void HitCoordinates(ref double X, ref double Y, double Distance)
        {
            Weap.HitCoordinates(ref X, ref Y, Distance);
        }
    }
}
