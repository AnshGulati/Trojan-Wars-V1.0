using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTypeNew : MonoBehaviour
{
    [SerializeField] public WeaponType weaponType; // Checking the type of Weapon

    // List of Weapon Types
    public enum WeaponType
    {
        Pistol, Shotgun, Rifle, MissileLauncher
    }

    // To get the key type

    public WeaponType GetWeaponType()
    {
        return weaponType;
    }
}
