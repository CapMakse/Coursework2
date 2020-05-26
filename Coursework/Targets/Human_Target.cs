﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Coursework.Targets
{
    class HumanTarget : Target
    {
        public override int GetScore(double X, double Y)
        {
            int Score = 0;
            CheckHit(X, Y, ref Score);
            CheckHearthShoot(X, Y, ref Score);
            CheckHeadShoot(X, Y, ref Score);
            return Score;
        }
        protected override void CheckHit(double X, double Y, ref int Score) {
            for (int BodyRingRadius = 100, CenterHeight = 300; Score < 7;)
            {
                if (CheckBodyRingHit(X, Y, BodyRingRadius, CenterHeight)) { Score++; }
                else break;
                BodyRingRadius -= 10;
                CenterHeight += 20;
            }
        }
        protected void CheckHeadShoot(double X, double Y, ref int Score)
        {
            for (int XHeadRingRadius = 80, YHeadRingRadius = 100, CenterHeight = 700, Incr = 8; Score < 10;)
            {
                if (CheckHeadRingHit(X, Y, XHeadRingRadius, YHeadRingRadius, CenterHeight)) 
                { 
                    Score += Incr;
                    Incr = 1;
                }
                else break;
                XHeadRingRadius -= 10;
                YHeadRingRadius -= 30;
                CenterHeight += 20;
            }
        }
        protected void CheckHearthShoot(double X, double Y, ref int Score)
        {
            if ((Math.Pow(((X - 25) / 35), 2) + Math.Pow(((Y - 425) / 45), 4)) <= 1) { Score = 10; }
        }
        private bool CheckBodyRingHit(double X, double Y, int Radius, int CenterHeight)
        {
            return (Math.Pow((X / (Radius * 2)), 4) + Math.Pow(((Y - CenterHeight) / (Radius * 3)), 6)) <= 1;
        }
        private bool CheckHeadRingHit(double X, double Y, int XRadius, int YRadius, int CenterHeight)
        {
            return (Math.Pow((X / XRadius), 4) + Math.Pow(((Y - CenterHeight) / YRadius), 2)) < 1;
        }
    }
}