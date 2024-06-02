using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats playerStats;
    public Player player;
    public GameObject hitbox;
    private BoxCollider2D hitboxCollider;
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

    public void Awake()
    {
        hitboxCollider = hitbox.GetComponent<BoxCollider2D>();
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
        Vector2 targetDirection;
        float distance = 0.2f;
        
        if (MathF.Sqrt(MathF.Pow(direction.x, 2)) > MathF.Sqrt(MathF.Pow(direction.y, 2)))
        {
            targetDirection = Vector2.right * direction * distance;
        }
        else
        {
            targetDirection = Vector2.up * direction * distance;
        }

        hitbox.transform.localPosition = targetDirection;
        // Debug.Log(targetDirection);
        Debug.Log(MathF.Abs(0));
    }

    public void colliderOn()
    {
        hitboxCollider.enabled = true;
    }
    public void colliderOff()
    {
        hitboxCollider.enabled = false;
    }

    private IEnumerator AttackRoutine()
    {
        IsAttacking = true;
        // Animation here
        Debug.Log($"Attacking for {playerStats.AttackCooldown}");

        // Attack Speed Cooldown
        yield return new WaitForSeconds(playerStats.AttackCooldown);
        // Hitbox = transform.Find("Hitbox").gameObject;
        PositionHitbox(player.movement.movementDirection);
        IsAttacking = false;
        // Use Animation Event to flash hitbox

        Debug.Log("Attack finished.");
    }
}