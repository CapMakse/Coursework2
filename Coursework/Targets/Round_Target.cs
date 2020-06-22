using System;

namespace Coursework.Targets
{
    /// <summary>
    /// Класс мишени "Круг"
    /// </summary>
    class RoundTarget : Target
    {
        public override int GetScore(double X, double Y)
        {
            int Score = 0;
            if (CheckHit(X, Y, ref Score)) return Score;
            return 0;
        }
        /// <summary>
        /// Проверяет попал ли игрок и в какой сектор, и соответстующе изменяет количество очков
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Score">Количество очков за выстрел</param>
        /// <returns>True если набрал очки, иначе false</returns>
        protected bool CheckHit(double X, double Y, ref int Score)
        {
            Score = 0;
            for (int TargetRingRadius = 300; TargetRingRadius >= 75; TargetRingRadius -= 25)
            {
                if (CheckRingHit(X, 0, TargetRingRadius, 2, Y, 300, TargetRingRadius, 2)) { Score++; }
                else break;
            }
            return Score > 0;
        }
        public override string GetTypeName()
        {
            return "Круг";
        }
    }
}
