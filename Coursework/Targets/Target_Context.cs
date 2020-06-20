
namespace Coursework.Targets
{
    class TargetContext
    {
        private Target Trg;
        public void SetTarget(Target Trg)
        {
            this.Trg = Trg;
        }
        public int GetScore(double X, double Y)
        {
            return Trg.GetScore(X, Y);
        }
        public bool CheckTarget()
        {
            return Trg == null;
        }
        public string GetTypeName()
        {
            return Trg.GetTypeName();
        }
    }
}
