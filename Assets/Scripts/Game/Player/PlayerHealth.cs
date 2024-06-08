using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public Transform spawnpoint;
    public AudioSource hitSound; // Add an AudioSource component
    public AudioClip hitClip; // Add a sound clip for the hit sound

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(maxHealth);
            transform.position = spawnpoint.position;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        PlayHitSound(); // Play the hit sound when taking damage
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kunti"))
        {
            TakeDamage(2);
        }
    }

    private void PlayHitSound()
    {
        hitSound.clip = hitClip;
        hitSound.Play();
    }
}