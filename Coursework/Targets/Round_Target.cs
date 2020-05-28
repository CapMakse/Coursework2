using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Targets
{
    class RoundTarget : Target
    {
        protected override bool CheckHit(double X, double Y, ref int Score)
        {
            Score = 0;
            for (int TargetRingRadius = 300; TargetRingRadius >= 75; TargetRingRadius -= 25)
            {
                if (CheckRingHit(X, Y, TargetRingRadius)) { Score++; }
                else break;
            }
            return Score > 0;
        }
        protected bool CheckRingHit(double X, double Y, int Radius)
        {
            return (Math.Pow((X / Radius), 2) + Math.Pow(((Y - 300) / Radius), 2)) <= 1;
        }
    }
}
