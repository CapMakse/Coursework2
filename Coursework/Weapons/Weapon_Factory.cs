
namespace Coursework.Weapons
{
    /// <summary>
    /// Абстрактный класс фабрики оружия
    /// </summary>
    abstract class WeaponFactory
    {
        /// <summary>
        /// Абстрактный фабричный метод
        /// </summary>
        /// <returns>Абстрактное оружие</returns>
        public abstract Weapon GetWeapon();
    }
    /// <summary>
    /// Класс фабрики пистолетов
    /// </summary>
    class PistolFactory : WeaponFactory
    {
        /// <summary>
        /// Реализация фабричного метода для пистолета
        /// </summary>
        /// <returns>Продукт - пистолет</returns>
        public override Weapon GetWeapon() { return new Pistol(); }
    }
    /// <summary>
    /// Класс фабрики штурмовых винтовок
    /// </summary>
    class AssaultRifleFactory : WeaponFactory
    {
        /// <summary>
        /// Реализация фабричного метода для штурмовой винтовки
        /// </summary>
        /// <returns>Продукт - штурмовая винтовка</returns>
        public override Weapon GetWeapon() { return new AssaultRifle(); }
    }
    /// <summary>
    /// Класс фабрики снайперских винтовок
    /// </summary>
    class SniperRifleFactory : WeaponFactory
    {
        /// <summary>
        /// Реализация фабричного метода для снайперской винтовки
        /// </summary>
        /// <returns>Продукт - снайперская винтовка</returns>
        public override Weapon GetWeapon() { return new SniperRifle(); }
    }
}
