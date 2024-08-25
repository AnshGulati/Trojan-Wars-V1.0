using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private float timeBtwShots;

    [SerializeField] private float startTimeBtwShots;

    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private GameObject muzzleFlash;

    [SerializeField] private Transform firePoint;

    [SerializeField] private Animator animator;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            audioManager.PlaySFX(audioManager.turretShoot);
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            GameObject muzzleEffect = Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
            Destroy(muzzleEffect, 0.35f);
            animator.SetBool("Shoot", true);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            animator.SetBool("Shoot", false);
        }
    }
}
