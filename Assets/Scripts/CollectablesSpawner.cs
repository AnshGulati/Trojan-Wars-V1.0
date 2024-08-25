using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectableToSpawn;

    [SerializeField] private Transform[] spawnPoints;

    // Spawn at the Start

    private void Start()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(collectableToSpawn, randomSpawnPoint.position, Quaternion.identity);
    }

}
