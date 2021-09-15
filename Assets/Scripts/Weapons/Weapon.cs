using UnityEngine;

public class Weapon
{
    public enum WeaponType {Knife, Pistol, Shotgun, SuperShotgun, Machinegun, Railgun, StickyLauncher, PizdechGun};
    public enum AmmoType {LightAmmo, ShotgunAmmo, EnergyAmmo, ExplodeAmmo};
    public enum BulletType {Hitscan, Projectile};

    public static string GetName(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return "Kazax Knife";
            case WeaponType.Pistol:         return "Little Pistol";
            case WeaponType.Shotgun:        return "Old-Love Shotgun";
            case WeaponType.SuperShotgun:   return "Double Shotgun";
            case WeaponType.Machinegun:     return "Big Brother";
            case WeaponType.Railgun:        return "Rail Gun";
            case WeaponType.StickyLauncher: return "Sticky Launcher";
            case WeaponType.PizdechGun:     return "PNG";
        }
    }

    public static string GetDescription(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return "Fresh Meat";
            case WeaponType.Pistol:         return "Little Pistol";
            case WeaponType.Shotgun:        return "Old-Love Shotgun";
            case WeaponType.SuperShotgun:   return "Double Shotgun";
            case WeaponType.Machinegun:     return "Big Brother";
            case WeaponType.Railgun:        return "Rail Gun";
            case WeaponType.StickyLauncher: return "Sticky Launcher";
            case WeaponType.PizdechGun:     return "PNG";
        }
    }

    public static int GetDamagePerBullet(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 5;
            case WeaponType.Pistol:         return 5;
            case WeaponType.Shotgun:        return 2;
            case WeaponType.SuperShotgun:   return 2;
            case WeaponType.Machinegun:     return 5;
            case WeaponType.Railgun:        return 12;
            case WeaponType.StickyLauncher: return 12;
            case WeaponType.PizdechGun:     return 69;
        }
    }

    public static float GetRateOfFire(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 0.3f;
            case WeaponType.Pistol:         return 0.5f;
            case WeaponType.Shotgun:        return 1f;
            case WeaponType.SuperShotgun:   return 1.3f;
            case WeaponType.Machinegun:     return 0.1f;
            case WeaponType.Railgun:        return 3f;
            case WeaponType.StickyLauncher: return 0.6f;
            case WeaponType.PizdechGun:     return 5f;
        }
    }


    public static int GetBulletsPerShoot(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 1;
            case WeaponType.Pistol:         return 1;
            case WeaponType.Shotgun:        return 5;
            case WeaponType.SuperShotgun:   return 10;
            case WeaponType.Machinegun:     return 2;
            case WeaponType.Railgun:        return 1;
            case WeaponType.StickyLauncher: return 1;
            case WeaponType.PizdechGun:     return 1;
        }
    }

    public static int GetAmmoPerShoot(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 0;
            case WeaponType.Pistol:         return 1;
            case WeaponType.Shotgun:        return 1;
            case WeaponType.SuperShotgun:   return 2;
            case WeaponType.Machinegun:     return 1;
            case WeaponType.Railgun:        return 5;
            case WeaponType.StickyLauncher: return 1;
            case WeaponType.PizdechGun:     return 30;
        }
    }

    public static float GetShootRange(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 2;
            case WeaponType.Pistol:         return 30;
            case WeaponType.Shotgun:        return 17;
            case WeaponType.SuperShotgun:   return 17;
            case WeaponType.Machinegun:     return 30;
            case WeaponType.Railgun:        return 60;
            case WeaponType.StickyLauncher: return 5;
            case WeaponType.PizdechGun:     return 100;
        }
    }

    public static float GetProjectileSpeed(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 100;
            case WeaponType.Pistol:         return 3;
            case WeaponType.Shotgun:        return 4;
            case WeaponType.SuperShotgun:   return 4;
            case WeaponType.Machinegun:     return 3;
            case WeaponType.Railgun:        return 60;
            case WeaponType.StickyLauncher: return 1;
            case WeaponType.PizdechGun:     return 100;
        }
    }

    public static float GetScatter(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 0f;
            case WeaponType.Pistol:         return 0.04f;
            case WeaponType.Shotgun:        return 0.1f;
            case WeaponType.SuperShotgun:   return 0.2f;
            case WeaponType.Machinegun:     return 0.07f;
            case WeaponType.Railgun:        return 0f;
            case WeaponType.StickyLauncher: return 0.03f;
            case WeaponType.PizdechGun:     return 0f;
        }
    }

    public static int GetAmmo(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Knife:          return 1;
            case WeaponType.Pistol:         return 30;
            case WeaponType.Shotgun:        return 10;
            case WeaponType.SuperShotgun:   return 10;
            case WeaponType.Machinegun:     return 50;
            case WeaponType.Railgun:        return 5;
            case WeaponType.StickyLauncher: return 7;
            case WeaponType.PizdechGun:     return 5;
        }
    }

    public static Weapon.AmmoType GetAmmoType(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Pistol:         return Weapon.AmmoType.LightAmmo;
            case WeaponType.Shotgun:        return Weapon.AmmoType.ShotgunAmmo;
            case WeaponType.SuperShotgun:   return Weapon.AmmoType.ShotgunAmmo;
            case WeaponType.Machinegun:     return Weapon.AmmoType.LightAmmo;
            case WeaponType.Railgun:        return Weapon.AmmoType.EnergyAmmo;
            case WeaponType.StickyLauncher: return Weapon.AmmoType.ExplodeAmmo;
            case WeaponType.PizdechGun:     return Weapon.AmmoType.EnergyAmmo;
        }
    }
}
