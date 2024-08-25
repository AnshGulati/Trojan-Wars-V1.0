using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherDestroyController : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void DestroyEnemyArcher(float delay)
    {
        audioManager.PlaySFX(audioManager.enemyDeath);
        Destroy(gameObject, delay);
    }
}
