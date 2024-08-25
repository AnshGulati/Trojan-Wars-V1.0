using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float changeDirectionCooldown;

    private Rigidbody2D rb;
    private EnemyTwo_AwarenessController enemyTwo_AwarenessController;
    private Vector2 targetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTwo_AwarenessController = GetComponent<EnemyTwo_AwarenessController>();
        targetDirection = transform.up; // Default Direction of Enemy
    }

    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if (changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (enemyTwo_AwarenessController.awareOfPlayer)
        {
            targetDirection = enemyTwo_AwarenessController.directionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {               
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {                    
        rb.velocity = transform.up * speed;        
    }
}
