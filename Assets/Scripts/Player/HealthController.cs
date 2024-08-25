using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    // Short Cooldown between two continous Damage streams
    public bool isInvincible { get; set; }

    // Player Dying Event 

    public UnityEvent OnDied;

    // Player Damage Event

    public UnityEvent OnDamaged;

    // Event for Health increase or health decrease

    public UnityEvent OnHealthChanged;

    public void TakeDamageFromEnemy(float damageAmount)
    {
        // If health is 0 then do nothing
        if (currentHealth == 0)
        {
            return;
        }

        // Player (After getting damage from enemy) gets short cooldown before next damage.
        if (isInvincible)
        {
            return;
        }

        // Current health minus damage 
        currentHealth -= damageAmount;

        // Invoking OnHealthChanged Event for health decrease
        OnHealthChanged.Invoke();

        // If health goes to -ve then make it zero
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // If health reaches zero then Player Dies
        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }

        // Everytime the Player takes damage the OnDamaged Event is invoked.
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd) // Health Pickups
    {
        // If health is already full then do nothing
        if (currentHealth == maxHealth)
        {
            return;
        }

        // Add Health to current health
        currentHealth += amountToAdd;

        // Invoking OnHealthChanged Event for Health increase
        OnHealthChanged.Invoke();

        // If health exceeds max health then make it equal to max health.
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
