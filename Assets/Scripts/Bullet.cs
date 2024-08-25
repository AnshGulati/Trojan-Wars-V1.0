using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectables")
        {
            return;
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.35f);
        Destroy(gameObject);

        if (collision.GetComponent<EnemyTwo_Movement>())
        {
            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamageFromEnemy(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamageFromEnemy(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Turret")
        {
            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamageFromEnemy(1);
            Destroy(gameObject);
        }
    }

}
