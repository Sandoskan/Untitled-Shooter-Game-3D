using System;
using UnityEngine;

[Serializable]
public class WeaponsInventory : MonoBehaviour
{
    private enum State {Knife, Pistol, Shotgun, SuperShotgun, Machinegun, Railgun, StickyLauncher, PizdechGun};
    private State _currectState;
    [SerializeField] private bool[] weaponsAvailable = new bool[(int)Weapon.WeaponType.PizdechGun];
    [SerializeField] private GameObject[] weaponsGameObjects = new GameObject[(int)Weapon.WeaponType.PizdechGun];
    [SerializeField] private KeyCode[] weaponKeycodes = new KeyCode[(int)Weapon.WeaponType.PizdechGun];

    [Header("Ammogus")]
    [SerializeField] private int shotgunBullets;
    [SerializeField] private int pistolBullets;
    [SerializeField] private int explodeBullets;
    [SerializeField] private int specialBullets;

    public bool[] GetAvailableWeapons()
    {
        return weaponsAvailable;
    }
    public int[] GetKeycodes()
    {
        int[] tmp = new int[weaponKeycodes.Length];
        for(int i = 0; i < weaponKeycodes.Length; i++)
        {
            tmp[i] = (int)weaponKeycodes[i];
        }

        return tmp;
    }
    public int[] GetAmmos()
    {
        int[] tmp = new int[4] { pistolBullets, shotgunBullets, explodeBullets, specialBullets };
        return tmp;
    }


    private void Awake()
    {
        for (int i = 0; i < (int)Weapon.WeaponType.PizdechGun; i++)
        {
            if (weaponsGameObjects[i].activeInHierarchy == true)
            {
                _currectState = (State)i;
                Debug.Log(_currectState);
            }
        }
    }

    public WeaponsInventory (WeaponsInventory weaponsInventory)
    {
        weaponsAvailable = weaponsInventory.weaponsAvailable;
        weaponKeycodes = weaponsInventory.weaponKeycodes;

        pistolBullets = weaponsInventory.pistolBullets;
        shotgunBullets = weaponsInventory.shotgunBullets;
        explodeBullets = weaponsInventory.explodeBullets;
        specialBullets = weaponsInventory.specialBullets;
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadDataWI();

        weaponsAvailable = data.weaponsAvailable;
        for(int i = 0; i < weaponKeycodes.Length; i++)
        {
            int[] tmp = data.weaponKeycodes;
            KeyCode keyCode = (KeyCode)tmp[i];
            weaponKeycodes[i] = keyCode;
        }

        pistolBullets = data.pistolBullets;
        shotgunBullets = data.shotgunBullets;
        explodeBullets = data.explodeBullets;
        specialBullets = data.specialBullets;
    }

    private void Update()
    {
        PressWeaponKeycode();
    }

    private void PressWeaponKeycode()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < (int)Weapon.WeaponType.PizdechGun; i++)
            {
                if (Input.GetKeyDown(weaponKeycodes[i]))
                {
                    if(weaponsAvailable[i] == true)
                        CheckWeapon(i);
                }
            }
        }
    }

    private void CheckWeapon(int i)
    {
        Debug.Log(_currectState);
        State _state = (State)i;
        Debug.Log(i);
        switch (_state)
        {
            default:
            case State.Knife:
                State state1 = State.Knife;
                if (_currectState != state1)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;
            case State.Pistol:
                State state2 = State.Pistol;
                if (_currectState != state2)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;
            case State.Shotgun:
                State state3 = State.Shotgun;
                if (_currectState != state3)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;
            case State.SuperShotgun:
                State state4 = State.SuperShotgun;
                if (_currectState != state4)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;
            case State.Machinegun:
                State state5 = State.Machinegun;
                if (_currectState != state5)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;
            case State.Railgun:
                State state6 = State.Railgun;
                if (_currectState != state6)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;
            case State.StickyLauncher:
                State state7 = State.StickyLauncher;
                if (_currectState != state7)
                {
                    weaponsGameObjects[(int)_currectState].SetActive(false);
                    weaponsGameObjects[i].SetActive(true);
                    _currectState = _state;
                }
                return;

        }
    }

    public void TakeWeapon(Weapon.WeaponType weapon)
    {
        int index = (int)weapon;
        if(weaponsAvailable[index] == false)
        {
            weaponsAvailable[index] = true;
        }
        else
        {
            RecycleIntoAmmo(weapon);
        }
    }

    private void RecycleIntoAmmo(Weapon.WeaponType weapon)
    {
        int bullets = Weapon.GetAmmo(weapon);

        switch (Weapon.GetAmmoType(weapon))
        {
            default:
            case Weapon.AmmoType.LightAmmo:
                pistolBullets += bullets;
                return;
            case Weapon.AmmoType.ShotgunAmmo:
                shotgunBullets += bullets;
                return;
            case Weapon.AmmoType.ExplodeAmmo:
                explodeBullets += bullets;
                return;
            case Weapon.AmmoType.EnergyAmmo:
                specialBullets += bullets;
                return;
        }
    }

    public bool TakenAmmo(Weapon.AmmoType ammoType, int ammoNeeds)
    {
        switch (ammoType)
        {
            default:
            case Weapon.AmmoType.LightAmmo:
                if(ammoNeeds > pistolBullets)
                {
                    return false;
                }
                else
                {
                    pistolBullets -= ammoNeeds;
                    return true;
                }

            case Weapon.AmmoType.ShotgunAmmo:
                if (ammoNeeds > shotgunBullets)
                {
                    return false;
                }
                else
                {
                    shotgunBullets -= ammoNeeds;
                    return true;
                }

            case Weapon.AmmoType.EnergyAmmo:
                if (ammoNeeds > specialBullets)
                {
                    return false;
                }
                else
                {
                    specialBullets -= ammoNeeds;
                    return true;
                }

            case Weapon.AmmoType.ExplodeAmmo:
                if (ammoNeeds > explodeBullets)
                {
                    return false;
                }
                else
                {
                    explodeBullets -= ammoNeeds;
                    return true;
                }
        }
    }
}
