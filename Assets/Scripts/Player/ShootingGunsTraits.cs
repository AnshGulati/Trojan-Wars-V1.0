using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShootingGunsTraits : MonoBehaviour
{
    public WeaponManagerNew weapon;

    // Aim Firepoints of Guns

    /*[SerializeField] private Transform pistolFirePoint;
    [SerializeField] private Transform shotgunFirePoint;
    [SerializeField] private Transform rifleFirePoint;
    [SerializeField] private Transform missileLauncherFirePoint;*/

    [SerializeField] private Transform firePoint;

    // Bullet Prefabs of Guns

    [SerializeField] private GameObject pistolBulletPrefab;
    [SerializeField] private GameObject shotgunBulletPrefab;
    [SerializeField] private GameObject rifleBulletPrefab;
    [SerializeField] private GameObject missileLauncherBulletPrefab;

    // Bullet Force of Guns

    [SerializeField] private float pistolBulletForce = 20f;
    [SerializeField] private float shotgunBulletForce = 20f;
    [SerializeField] private float rifleBulletForce = 20f;
    [SerializeField] private float missileLauncherBulletForce = 20f;


    public int currentClip;
    public int maxClipSize;
    public int currentAmmo;
    public int maxAmmoSize;

    private void Update()
    {
        if (weapon.currentGun.name.StartsWith("Pistol"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("P");
                PistolShoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("P-reload");
                Reload(0,20,10,10);
            }
        }

        if (weapon.currentGun.name.StartsWith("Shotgun"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("S");
                ShotgunShoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("S-reload");
                Reload(0, 10, 7, 7);
            }
        }

        if (weapon.currentGun.name.StartsWith("Rifle"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("R");
                RifleShoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R-reload");
                Reload(0, 30, 15, 15);
            }
        }

        if (weapon.currentGun.name.StartsWith("MissileLauncher"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("M");
                MissileLauncherShoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("M-reload");
                Reload(0, 10, 5, 5);
            }
        }
    }

    private void PistolShoot()
    {
        if (currentClip > 0)
        {
            GameObject pistolBullet = Instantiate(pistolBulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = pistolBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * pistolBulletForce, ForceMode2D.Impulse);
            currentClip--;
        }
    }

    private void ShotgunShoot()
    {
        if (currentClip > 0)
        {
            GameObject shotgunBullet = Instantiate(shotgunBulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = shotgunBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * shotgunBulletForce, ForceMode2D.Impulse);
            currentClip--;
        }
    }

    private void RifleShoot()
    {
        if (currentClip > 0)
        {
            GameObject rifleBullet = Instantiate(rifleBulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = rifleBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * rifleBulletForce, ForceMode2D.Impulse);
            currentClip--;
        }
    }

    private void MissileLauncherShoot()
    {
        if (currentClip > 0)
        {
            GameObject missileLauncherBullet = Instantiate(missileLauncherBulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = missileLauncherBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * missileLauncherBulletForce, ForceMode2D.Impulse);
            currentClip--;
        }
    }

    public void Reload(int clipSize, int maxClip, int ammoSize, int maxAmmo)
    {
        // How many Bullets to refill clip
        int reloadAmount = maxClip - clipSize;
        reloadAmount = (ammoSize - reloadAmount) >= 0 ? reloadAmount : ammoSize;
        clipSize += reloadAmount;
        ammoSize -= reloadAmount;

    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }
}