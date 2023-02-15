using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public int currentHealth;
    public HealthBar healthBar;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(1);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
