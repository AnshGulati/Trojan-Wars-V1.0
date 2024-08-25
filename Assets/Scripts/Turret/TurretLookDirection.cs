using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookDirection : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction vector from the enemy to the player
            Vector3 direction = player.position - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the rotation of the enemy to face the player
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
