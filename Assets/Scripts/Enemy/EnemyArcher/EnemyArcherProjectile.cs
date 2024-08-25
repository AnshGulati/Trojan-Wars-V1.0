using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherProjectile : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    [SerializeField] private float speed;

    private Transform player;
    private Vector2 target;

    [SerializeField] private GameObject hitEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectables")
        {
            return;
        }

        if (other.gameObject.tag == "Enemy")
        {
            return;
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.35f);
        DestroyProjectile();

        if (other.CompareTag("Player"))
        {
            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);

            var healthController = other.gameObject.GetComponent<HealthController>();
            healthController.TakeDamageFromEnemy(damageAmount);

            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
