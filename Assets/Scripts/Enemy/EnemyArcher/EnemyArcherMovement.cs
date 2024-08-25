using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyArcherMovement : MonoBehaviour
{
    public AIPath aiPath;

    Vector2 direction;

    private void Update()
    {
        faceVelocity();
    }

    private void faceVelocity()
    {
        direction = aiPath.desiredVelocity;

        transform.right = direction;
    }
}
