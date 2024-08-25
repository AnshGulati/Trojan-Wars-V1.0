using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEngine.GraphicsBuffer;

public class EnemyArcherLookDirection : MonoBehaviour
{
    /*[SerializeField] private float rotationSpeed;

    private Vector2 targetDirection;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }*/

    public Transform target; // Reference to the player's transform
    private AIPath aiPath; // Reference to the AIPath component for pathfinding

    void Start()
    {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                // Now you can use playerTransform for whatever you need
            }
 
        aiPath = GetComponent<AIPath>();
    }

    void Update()
    {
        if (target != null && aiPath != null)
        {
            // Calculate the direction vector from the enemy to the player
            Vector2 direction = target.position - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the rotation of the enemy to face the player
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Update the pathfinding target to the player's position
            aiPath.destination = target.position;
        }
    }
}
