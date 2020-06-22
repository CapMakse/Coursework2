using System;

namespace Coursework.Weapons
{
    /// <summary>
    /// Абстрактный класс оружия (продукта)
    /// </summary>
    abstract class Weapon
    {
        protected double Radius;
        protected double BulletEnergy;
        protected string TypeName;
        /// <summary>
        /// Изменяет координаты прицеливаня на координаты попадания
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Distance">Растояние до мишени</param>
        public void GetHitCoordinates(ref double X, ref double Y, int Distance)
        {
            WeaponScatter(ref X, ref Y, Distance);
            BulletBallistics(ref Y, Distance);
        }
        /// <summary>
        /// Изменяет координаты в зависимости от кучности оружия
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Distance">Растояние до мишени</param>
        protected void WeaponScatter(ref double X, ref double Y, int Distance)
        {
            Random rnd = new Random();
            double NewRadius = rnd.NextDouble() * Radius * Distance;
            double NewAngle = rnd.NextDouble() * 2 * Math.PI;
            X += NewRadius * Math.Cos(NewAngle);
            Y += NewRadius * Math.Sin(NewAngle);
        }
        /// <summary>
        /// Изменяет координату в зависимости от мощности оружия и растояния до мишени (баллистика)
        /// </summary>
        /// <param name="Y">Вертикальная координата</param>
        /// <param name="Distance">Растояние до мишени</param>
        protected void BulletBallistics(ref double Y, int Distance)
        {
            Y -= Math.Pow((Distance / BulletEnergy), 3);
        }
        /// <summary>
        /// Возвращает название типа оружия
        /// </summary>
        /// <returns>Тип оружия</returns>
        public string GetTypeName()
        {
            return TypeName;
        }
    }
}
