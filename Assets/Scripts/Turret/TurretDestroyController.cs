using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDestroyController : MonoBehaviour
{
    public GameObject turretExplosion;
    public GameObject redKeySpawnOnDestroy;

    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void DestroyTurret(float delay)
    {
        audioManager.PlaySFX(audioManager.turretExplode);
        GameObject explosionEffect = Instantiate(turretExplosion, transform.position, Quaternion.identity);
        Destroy(explosionEffect, 0.85f);
        Instantiate(redKeySpawnOnDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject, delay);
    }
}
