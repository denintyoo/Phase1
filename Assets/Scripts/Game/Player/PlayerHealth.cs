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

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}