using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherAttack : MonoBehaviour
{
    private float timeBtwShots;

    [SerializeField] private float startTimeBtwShots;

    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform firePoint;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
