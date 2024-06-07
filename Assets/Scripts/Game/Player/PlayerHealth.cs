using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  //public void TakeDamage(int damage)
    //{
     // if (!invincible)
    //  {
     //   Debug.Log(damage);
    //    invincible = true;
       // StartCoroutine(startinvicibletimer());
      //}
        
   // }

  //private bool invincible = false;
  //private IEnumerator startinvicibletimer()
 // {
   // yield return new WaitForSeconds(1);
   // invincible = false;
 // }

    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public Transform spawnpoint;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kunti"))
        {
            TakeDamage(2);
        }
    }
}