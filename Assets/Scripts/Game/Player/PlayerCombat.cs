using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public PlayerStats playerStats;
    public Player player;
    private BoxCollider2D Hitbox;
    private bool isAttacking = false;
    public bool IsAttacking
    {
        get { return isAttacking; }
        private set 
            { 
                isAttacking = value; 
                player.movement.SetCanMove(!isAttacking);
                Debug.Log($"set canmove to{isAttacking}");
            }
    }

    public void DoAttack()
    {
        if (!IsAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }
    private void PositionHitbox(Vector2 direction)
    {
        float distance = 1.0f;
        Hitbox.transform.localPosition = direction * distance;
    }

    private IEnumerator AttackRoutine()
    {
        IsAttacking = true;
        // Animation here
        Debug.Log($"Attacking for {playerStats.AttackCooldown}");

        // Attack Speed Cooldown
        yield return new WaitForSeconds(playerStats.AttackCooldown);
        IsAttacking = false;
        
        Debug.Log("Attack finished.");
    }
}