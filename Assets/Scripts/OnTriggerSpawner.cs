using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSpawner : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject spawnerGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            spawnerGameObject.SetActive(true);
        }
        
    }
}
