using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    private float nextSpawnTime;

    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private int maxSpawnCount = 15;
    private int spawnCount = 0;

    private void Update()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (spawnCount < maxSpawnCount && Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);
            spawnCount++;
        }
    }
}
