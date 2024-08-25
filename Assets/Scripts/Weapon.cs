using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public event EventHandler OnAmmoChanged;

    public enum WeaponType
    {
        Pistol,
        Shotgun,
        Rifle
    }

    private WeaponType weaponType;
    private int ammo;

    public Weapon(WeaponType weaponType)
    {
        this.weaponType = weaponType;
        ammo = GetAmmoMax();
    }

    public WeaponType GetWeaponType()
    {
        return weaponType;
    }

    public int GetAmmo()
    {
        return ammo;
    }

    public bool TrySpendAmmo()
    {
        if (ammo > 0)
        {
            ammo--;
            OnAmmoChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reload()
    {
        ammo = GetAmmoMax();
        OnAmmoChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool CanReload()
    {
        return ammo < GetAmmoMax();
    }

    public int GetAmmoMax()
    {
        switch (weaponType)
        {
            default:
                return 99;
            case WeaponType.Pistol:
                return 12;
            case WeaponType.Shotgun:
                return 4;
            case WeaponType.Rifle:
                return 25;
        }
    }

    public float GetDamageMultiplier()
    {
        switch (weaponType)
        {
            default:
            case WeaponType.Pistol: return 1.2f;
            case WeaponType.Shotgun: return 1.9f;
            case WeaponType.Rifle: return 0.6f;
        }
    }

    public float GetFireRate()
    {
        switch (weaponType)
        {
            default:
            case WeaponType.Pistol: return .15f;
            case WeaponType.Shotgun: return .20f;
            case WeaponType.Rifle: return .09f;
        }
    }

    /*public Sprite GetSprite()
    {
        switch (weaponType)
        {
            default:
            case WeaponType.Pistol: return Weapon.i.s_PistolIcon;
            case WeaponType.Shotgun: return Weapon.i.s_ShotgunIcon;
            case WeaponType.Rifle: return Weapon.i.s_RifleIcon;
        }
    }*/
}
