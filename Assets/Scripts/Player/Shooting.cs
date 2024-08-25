using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;

    public int currentClip;
    public int maxClipSize = 10;
    public int currentAmmo;
    public int maxAmmoSize = 100;

    //private PauseMenu pauseMenu;

    private void Update()
    {
        if ((!(PauseMenu.GameIsPaused)) && Input.GetButtonDown("Fire1"))
        {
            
            Shoot();

            
        }

        if ((!(PauseMenu.GameIsPaused)) && Input.GetKeyDown(KeyCode.R))
        {
            audioManager.PlaySFX(audioManager.gunReload);
            Reload();
        }
    }

    private void Shoot()
    {
        if (currentClip > 0)
        {
            audioManager.PlaySFX(audioManager.playerShoot);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            currentClip--; 
        }

        if (currentClip == 0)
        {
            audioManager.PlaySFX(audioManager.emptyClipGun);
        }

    }

    public void Reload()
    {
        // How many Bullets to refill clip
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
        
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
