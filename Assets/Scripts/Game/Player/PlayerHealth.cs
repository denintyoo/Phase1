using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public void TakeDamage(int damage)
    {
      if (!invincible)
      {
        Debug.Log(damage);
        invincible = true;
        StartCoroutine(startinvicibletimer());
      }
        
    }
    
  private bool invincible = false;
  private IEnumerator startinvicibletimer()
  {
    yield return new WaitForSeconds(1);
    invincible = false;
  }
}