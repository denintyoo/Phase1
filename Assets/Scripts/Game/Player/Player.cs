using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
//   public PlayerHealth health;
  public PlayerMovement movement;
  public PlayerCombat combat;
  public Stats stats;

  private void Start()
  {
    // health = GetComponent<PlayerHealth>();
    // if (health == null)
    //     {
    //         Debug.LogError("PlayerHealth component not found on game object.");
    //     }
    movement = GetComponent<PlayerMovement>();
    if (movement == null)
        {
            Debug.LogError("PlayerMovement component not found on game object.");
        }
    combat = GetComponent<PlayerCombat>();
    if (combat == null)
        {
            Debug.LogError("PlayerCombat component not found on game object.");
        }
    stats = GetComponent<PlayerStats>();
    if (stats == null)
        {
            Debug.LogError("PlayerStats component not found on game object.");
        }
  }
}