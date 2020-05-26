using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework.Targets
{
    abstract class Target
    {
        public virtual int GetScore(double X, double Y)
        {
            int Score = 0;
            CheckHit(X, Y, ref Score);
            return Score;
        }
        protected abstract void CheckHit(double X, double Y, ref int Score);
    }
}
