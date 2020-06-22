namespace Coursework.Weapons
{
    /// <summary>
    /// Продукт - пистолет
    /// </summary>
    class Pistol : Weapon
    {
        public Pistol() { Radius = 0.75; BulletEnergy = 50; TypeName = "Пистолет"; }
    }
    /// <summary>
    /// Продукт - Штурмовая винтовка
    /// </summary>
    class AssaultRifle : Weapon
    {
        public AssaultRifle() { Radius = 0.5; BulletEnergy = 150; TypeName = "Автомат"; }
    }
    /// <summary>
    /// Продукт - снайпесркая винтовка
    /// </summary>
    class SniperRifle : Weapon
    {
        public SniperRifle() { Radius = 0.1; BulletEnergy = 300; TypeName = "Снайперская винтовка"; }
    }
}
