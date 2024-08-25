using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollectableDrop : MonoBehaviour
{
    [SerializeField] private float chanceOfCollectableDrop;

    private CollectableSpawner collectableSpawner;

    private void Awake()
    {
        collectableSpawner = FindObjectOfType<CollectableSpawner>();
    }

    public void RandomlyDropCollectable()
    {
        float random = Random.Range(0f, 1f);

        if (chanceOfCollectableDrop >= random)
        {
            collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
