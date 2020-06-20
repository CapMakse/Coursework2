
namespace Coursework.Targets
{
    abstract class Target
    {
        public virtual int GetScore(double X, double Y)
        {
            int Score = 0;
            if (CheckHit(X, Y, ref Score)) return Score;
            return 0;
        }
        protected abstract bool CheckHit(double X, double Y, ref int Score);
        public abstract string GetTypeName();
    }
}
