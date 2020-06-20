
namespace Coursework.Weapons
{
    abstract class WeaponFactory
    {
        public abstract Weapon GetWeapon();
    }
    class PistolFactory : WeaponFactory
    {
        public override Weapon GetWeapon() { return new Pistol(); }
    }
    class AssaultRifleFactory : WeaponFactory
    {
        public override Weapon GetWeapon() { return new AssaultRifle(); }
    }
    class SniperRifleFactory : WeaponFactory
    {
        public override Weapon GetWeapon() { return new SniperRifle(); }
    }
}
