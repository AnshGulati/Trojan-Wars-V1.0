using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo_DestroyController : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void DestroyEnemy(float delay)
    {
        audioManager.PlaySFX(audioManager.enemyDeath);
        Destroy(gameObject, delay);
    }
}
