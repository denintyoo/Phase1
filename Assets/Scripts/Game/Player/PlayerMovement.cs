using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool lastIsLeft; // to verify that last direction is left (delete and edit playerAnimator if player already have separate left and right idle sprite)
    public bool canMove = true;
    private bool moving = false;
    public Vector2 movementDirection;

    

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void MovementHandler()
    {
        if (canMove) // If canMove is true then enable moving components. Else? Don't move
        {
            movementDirection.x = Input.GetAxisRaw("Horizontal");
            movementDirection.y = Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(movementDirection.x, movementDirection.y).normalized;
            // Debug.Log($"direction {movementDirection}");
            
            AnimationHandler();
            // animator.SetFloat("Horizontal", movement.x);
            // animator.SetFloat("Vertical", movement.y);
            // animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            rb.velocity = Vector2.zero;
            // Debug.Log("cannot move");
            animator.SetFloat("Speed", 0);
        }
    }

    // Magic happens here
    private void AnimationHandler()
    {   
        if (movementDirection.magnitude > 0.1f || movementDirection.magnitude < -0.1f)    // Check if moving and assign to "moving"
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        
        //* LastIsLeft Checker
        if (movementDirection.x < 0)                                            // Check if last horizontal movementDirection is to the left (Delete if player have both side of horizontal animation)
        {
            lastIsLeft = true;
        }
        else if (movementDirection.x > 0 || movementDirection.y != 0)                   // if any other direction is the last movementDirection, set to false
        {
            lastIsLeft = false;
        }

        if (lastIsLeft == true && !moving)                            // Check if LastIsLeft and not moving, then flipX
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (moving)                                                     // if "moving" is true then animate 4 cardinal direction
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }

        animator.SetBool("Moving", moving);
    }

    public void UpdatePosition(int moveSpeed)
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime); 
        }
        else
        {
            rb.MovePosition(rb.position);
        }
    }

    // This is to stop the player movementDirection if the player casting / attacking.
    public void SetCanMove(bool value)
    {
        canMove = value;
        Debug.Log($"set canmove to{canMove}");
    }

    
}

