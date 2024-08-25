using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OnTriggerTurretStart : MonoBehaviour
{
    [SerializeField] private GameObject turretAttack ;

    /*private void Start()
    {
        // Get the TurretAttack component attached to the same GameObject
        turretAttack = GetComponent<TurretAttack>();
        if (turretAttack == null)
        {
            Debug.LogError("TurretAttack component not found on the same GameObject.");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            turretAttack.SetActive(true);
            Destroy(gameObject);
        }

    }
}
