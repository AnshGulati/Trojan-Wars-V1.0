using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryNew : MonoBehaviour
{
    public event EventHandler OnWeaponChanged;

    private List<WeaponTypeNew.WeaponType> weaponList;

    // Weapons GameObjects
    public GameObject missileLauncher;
    public GameObject shotgun;
    public GameObject rifle;
    public GameObject gunHolder;

    private void Awake()
    {
        weaponList = new List<WeaponTypeNew.WeaponType>();
    }

    //Function for exposing our Weapon Inventory to UI

    public List<WeaponTypeNew.WeaponType> GetWeaponList()
    {
        return weaponList;
    }

    // Add the Weapon to Inventory

    public void AddWeapon(WeaponTypeNew.WeaponType weaponType)
    {
        weaponList.Add(weaponType);
        OnWeaponChanged?.Invoke(this, EventArgs.Empty);
    }

    // Remove the Weapon from Inventory

    public void RemoveWeapon(WeaponTypeNew.WeaponType weaponType)
    {
        weaponList.Remove(weaponType);
        OnWeaponChanged?.Invoke(this, EventArgs.Empty);
    }

    // Check that the Weapon is in the inventory or not

    public bool ContainsWeapon(WeaponTypeNew.WeaponType weaponType)
    {
        return weaponList.Contains(weaponType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        WeaponTypeNew weapon = collider.GetComponent<WeaponTypeNew>();

        // If player collides with the Weapon, then he grabs the Weapon

        if (weapon != null)
        {
            AddWeapon(weapon.GetWeaponType());
            if (weapon.GetWeaponType() == WeaponTypeNew.WeaponType.Shotgun)
            {
                Instantiate(shotgun, gunHolder.transform);
                GetComponentInChildren<WeaponManagerNew>().UpdateGuns();
            }
            if (weapon.GetWeaponType() == WeaponTypeNew.WeaponType.Rifle)
            {
                Instantiate(rifle, gunHolder.transform);
                GetComponentInChildren<WeaponManagerNew>().UpdateGuns();
            }
            if (weapon.GetWeaponType() == WeaponTypeNew.WeaponType.MissileLauncher)
            {
                Instantiate(missileLauncher, gunHolder.transform);
                GetComponentInChildren<WeaponManagerNew>().UpdateGuns();
            }
            Destroy(weapon.gameObject);
        }
    }
}
