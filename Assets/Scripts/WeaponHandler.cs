using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler Instance { get; private set; }

    private PlayerMain playerMain;

    public event EventHandler OnWeaponChanged;
    public event EventHandler OnPickedUpWeapon;

    private Weapon weapon;
    private Weapon weaponPistol;
    private Weapon weaponShotgun;
    private Weapon weaponRifle;

    private bool canUseShotgun;
    private bool canUseRifle;

    private void Awake()
    {
        Instance = this;
        playerMain = GetComponent<PlayerMain>();

        weaponPistol = new Weapon(Weapon.WeaponType.Pistol);
        weaponShotgun = new Weapon(Weapon.WeaponType.Shotgun);
        weaponRifle = new Weapon(Weapon.WeaponType.Rifle);
    }

    private void Start()
    {
        SetWeapon(weaponPistol);
        //playerMain.PlayerSwapAimNormal.OnShoot += PlayerSwapAimNormal_OnShoot;
    }

    public void SetCanUseShotgun()
    {
        canUseShotgun = true;
        SetWeapon(weaponShotgun);
    }

    public void SetCanUseRifle()
    {
        canUseRifle = true;
        SetWeapon(weaponRifle);
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        /*playerMain.PlayerSwapAimNormal.SetWeapon(weapon);*/
        OnWeaponChanged?.Invoke(this, EventArgs.Empty);
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(weaponPistol);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && canUseShotgun)
        {
            SetWeapon(weaponShotgun);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && canUseRifle)
        {
            SetWeapon(weaponRifle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PickupShotgun>() != null)
        {
            // Shotgun
            //materialTintColor.SetTintColor(Color.blue);
            SetCanUseShotgun();
            Destroy(collider.gameObject);
            OnPickedUpWeapon?.Invoke(Weapon.WeaponType.Shotgun, EventArgs.Empty);
        }

        if (collider.GetComponent<PickupRifle>() != null)
        {
            // Shotgun
            //materialTintColor.SetTintColor(Color.blue);
            SetCanUseRifle();
            Destroy(collider.gameObject);
            OnPickedUpWeapon?.Invoke(Weapon.WeaponType.Rifle, EventArgs.Empty);
        }
    }


}
