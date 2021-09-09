using UnityEngine;

public class Weapon
{
    public enum WeaponType {Shotgun, Pistol, StickyLauncher, Railgun, Machinegun, SuperShotgun, PizdechGun};

    public string GetName(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Pistol:         return "Little Pistol";
            case WeaponType.Shotgun:        return "Old-Love Shotgun";
            case WeaponType.SuperShotgun:   return "Double Shotgun";
            case WeaponType.Machinegun:     return "Big Brother";
            case WeaponType.Railgun:        return "Rail Gun";
            case WeaponType.StickyLauncher: return "Sticky Launcher";
            case WeaponType.PizdechGun:     return "PNG";
        }
    }

    public string GetDescription(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Pistol:         return "Little Pistol";
            case WeaponType.Shotgun:        return "Old-Love Shotgun";
            case WeaponType.SuperShotgun:   return "Double Shotgun";
            case WeaponType.Machinegun:     return "Big Brother";
            case WeaponType.Railgun:        return "Rail Gun";
            case WeaponType.StickyLauncher: return "Sticky Launcher";
            case WeaponType.PizdechGun:     return "PNG";
        }
    }

    public int GetAmmo(Weapon.WeaponType weapon)
    {
        switch (weapon)
        {
            default:
            case WeaponType.Pistol:         return 30;
            case WeaponType.Shotgun:        return 10;
            case WeaponType.SuperShotgun:   return 10;
            case WeaponType.Machinegun:     return 50;
            case WeaponType.Railgun:        return 5;
            case WeaponType.StickyLauncher: return 7;
            case WeaponType.PizdechGun:     return 5;
        }
    }
}
