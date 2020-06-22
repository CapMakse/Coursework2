using System;

namespace Coursework.Targets
{
    /// <summary>
    /// Прототип класса мишени
    /// </summary>
    abstract class Target
    {
        /// <summary>
        /// Получает очки за выстрел
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <returns>Очки за выстрел</returns>
        public abstract int GetScore(double X, double Y);
        /// <summary>
        /// Проверяет попал ли в определенный сектор мишени
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="XShift">Горизонтальный сдвиг</param>
        /// <param name="YShift">Вертикальный сдвиг</param>
        /// <param name="XRadius">Горизонтальный радиус</param>
        /// <param name="YRadius">Вертикальный радиус</param>
        /// <param name="XCurve">Горизонтальная кривизна</param>
        /// <param name="YCurve">Вертикальная кривизна</param>
        /// <returns>True если попал, иначе false</returns>
        protected bool CheckRingHit(double X, double XShift, int XRadius, double XCurve, double Y, double YShift, int YRadius, double YCurve)
        {
            return (Math.Pow(((X - XShift) / XRadius), XCurve) + Math.Pow(((Y - YShift) / YRadius), YCurve)) <= 1;
        }
        /// <summary>
        /// Возвращает название типа мишени
        /// </summary>
        /// <returns>Тип мишени</returns>
        public abstract string GetTypeName();
    }
}
