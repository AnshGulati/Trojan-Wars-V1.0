using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        // audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ShootingGunsTraits shooting = collision.gameObject.GetComponentInChildren<ShootingGunsTraits>();
        Shooting shooting = collision.gameObject.GetComponentInChildren<Shooting>();
        if (shooting)
        {
            audioManager.PlaySFX(audioManager.ammoCollect);
            shooting.AddAmmo(shooting.maxAmmoSize);
            Destroy(gameObject);
        }
    }
}
