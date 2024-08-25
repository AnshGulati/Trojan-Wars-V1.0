using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed; //Enemy Speed
    Transform player;

    [SerializeField] private int health; //Enemy Health

    [SerializeField] private GameObject deathEffect;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // Enemy Movement
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Take Damage on Bullet Hit

        if (other.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Bullet>().damage);
        }


        // If gets contact with player then Game Over

        /*if (other.tag == "Player")
        {
            SceneManager.LoadScene("GamePlay");
        }*/
    }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GameObject bloodSpatterEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(bloodSpatterEffect, 0.4f);
            Destroy(gameObject);
        }
    }
}
