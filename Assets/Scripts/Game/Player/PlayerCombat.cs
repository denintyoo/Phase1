using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats playerStats;
    public Player player;
    private bool isAttacking;
    public bool IsAttacking
    {
        get { return isAttacking; }
        private set 
            { 
                isAttacking = value; 
                player.movement.SetCanMove(isAttacking);
            }
    }

    public void DoAttack()
    {
        if (!IsAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        IsAttacking = true;
        // Animation here
        Debug.Log("Attacking...");

        // Attack Speed Cooldown
        yield return new WaitForSeconds(playerStats.AttackCooldown);
        Debug.Log($"Cooldown for{playerStats.AttackCooldown}");

        IsAttacking = false;
        
        Debug.Log("Attack finished.");
    }
}