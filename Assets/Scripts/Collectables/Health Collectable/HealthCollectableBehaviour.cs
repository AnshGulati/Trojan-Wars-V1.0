using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    AudioManager audioManager;

    [SerializeField] private float healthAmount;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void OnCollected(GameObject player)
    {
        audioManager.PlaySFX(audioManager.heal);
        player.GetComponent<HealthController>().AddHealth(healthAmount);
    }
}
