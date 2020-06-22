using System;

namespace Coursework.Targets
{
    /// <summary>
    /// Класс мишени "Человек"
    /// </summary>
    class HumanTarget : Target
    {
        public override int GetScore(double X, double Y)
        {
            int Score = 0;
            if (CheckHearthShoot(X, Y, ref Score)) return Score;
            if (CheckHeadShoot(X, Y, ref Score)) return Score;
            if (CheckBodyHit(X, Y, ref Score)) return Score;
            return 0;
        }
        /// <summary>
        /// Проверяет попал ли игрок в тело и в какую именно часть, и соответстующе изменяет количество очков
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Score">Количество очков за выстрел</param>
        /// <returns>True если набрал очки, иначе false</returns>
        protected bool CheckBodyHit(double X, double Y, ref int Score) {
            for (int BodyRingRadius = 100, CenterHeight = 300; Score < 7;)
            {
                if (CheckRingHit(X, 0, BodyRingRadius * 2, 4, Y, CenterHeight, BodyRingRadius * 3, 6)) { Score++; }
                else break;
                BodyRingRadius -= 10;
                CenterHeight += 20;
            }
            return Score > 0;
        }
        /// <summary>
        /// Проверяет попал ли игрок в голову и в какую именно часть, и соответстующе изменяет количество очков
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Score">Количество очков за выстрел</param>
        /// <returns>True если набрал очки, иначе false</returns>
        protected bool CheckHeadShoot(double X, double Y, ref int Score)
        {
            for (int XHeadRingRadius = 80, YHeadRingRadius = 100, CenterHeight = 700, Incr = 8; Score < 10;)
            {
                if (CheckRingHit(X, 0, XHeadRingRadius, 4, Y, CenterHeight, YHeadRingRadius, 2)) 
                { 
                    Score += Incr;
                    Incr = 1;
                }
                else break;
                XHeadRingRadius -= 10;
                YHeadRingRadius -= 30;
                CenterHeight += 20;
            }
            return Score > 0;
        }
        /// <summary>
        /// Проверяет попал ли игрок в сердце и соответстующе изменяет количество очков
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Score">Количество очков за выстрел</param>
        /// <returns>True если набрал очки, иначе false</returns>
        protected bool CheckHearthShoot(double X, double Y, ref int Score)
        {
            if (CheckRingHit(X, 25, 35, 2, Y, 425, 45, 4)) 
            {
                Score = 10;
                return true;
            }
            return false;
        }
        public override string GetTypeName()
        {
            return "Человек";
        }
    }
}
