using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();

            healthController.TakeDamageFromEnemy(damageAmount);
        }
    }
}
