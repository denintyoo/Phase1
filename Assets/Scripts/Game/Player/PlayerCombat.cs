using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats playerStats;
    public Player player;
    public GameObject hitbox;
    private BoxCollider2D hitboxCollider;
    private bool isAttacking = false;
    private Animator animator;
    public bool IsAttacking
    {
        get { return isAttacking; }
        private set 
            { 
                isAttacking = value; 
                player.movement.SetCanMove(!isAttacking);
                Debug.Log($"set canmove to {!isAttacking}");
            }
    }

    public void Awake()
    {
        hitboxCollider = hitbox.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    public void DoAttack()
    {
        if (!IsAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }
    private void PositionHitbox(string direction)
    {
        // Vector2 targetDirection;
        float distance = 0.2f;
        Vector2 targetDirection = Vector2.zero;


        // if (Mathf.Sqrt(MathF.Pow(direction.x, 2)) > MathF.Sqrt(MathF.Pow(direction.y, 2)))
        // {
        //     targetDirection = Vector2.right * direction * distance;
        // }
        // else
        // {
        //     targetDirection = Vector2.up * direction * distance;
        // }

        // hitbox.transform.localPosition = targetDirection;

        // Debug.Log(targetDirection);

        if (direction == "Left")
        {
            targetDirection = Vector2.left * distance;
        } 
        else if (direction == "Right")
        {
            targetDirection = Vector2.right * distance;
        }
        else if (direction == "Up")
        {
            targetDirection = Vector2.up * distance;
        }
        else if (direction == "Down")
        {
            targetDirection = Vector2.down * distance;
        }

        hitbox.transform.localPosition = targetDirection;
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
        // Debug.Log($"Attacking for {playerStats.AttackCooldown}");

        PositionHitbox(player.movement.lastDirection);
        Debug.Log($"I'm Attacking! {IsAttacking}");

        animator.SetTrigger("Attack");
        hitboxCollider.enabled = true;
        // Attack Speed Cooldown
        yield return new WaitForSeconds(playerStats.AttackCooldown);

        hitboxCollider.enabled = false;
        // Use Animation Event to flash hitbox
        IsAttacking = false;

        // Debug.Log("Attack finished.");
    }
}