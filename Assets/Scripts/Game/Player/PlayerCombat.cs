using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool IsAttacking
    {
        get { return IsAttacking; }
        public set { IsAttacking = value; }
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
        yield return new WaitForSeconds(playerStats.attackDuration);
        Debug.Log($"Cooldown for{playerStats.attackDuration}");

        IsAttacking = false;
        
        Debug.Log("Attack finished.");
    }
}