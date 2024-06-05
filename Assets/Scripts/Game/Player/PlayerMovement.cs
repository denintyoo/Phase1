using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    // private SpriteRenderer spriteRenderer;
    [SerializeField] public string lastDirection;
    public bool canMove = true;
    private bool moving = false;
    public Vector2 movementDirection;

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void MovementHandler()
    {
        if (canMove) // If canMove is true then enable moving components. Else? Don't move
        {
            movementDirection.x = Input.GetAxisRaw("Horizontal");
            movementDirection.y = Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(movementDirection.x, movementDirection.y).normalized;
            // animator.SetFloat("Horizontal", movementDirection.x);
            // animator.SetFloat("Vertical", movementDirection.y);
            // animator.SetFloat("Speed", movementDirection.sqrMagnitude);

            if (movementDirection.magnitude > 0.1f || movementDirection.magnitude < -0.1f)    // Check if moving and assign to "moving"
            {
                moving = true;
                // Store Last Movement Direction
                if (movementDirection.y > 0)
                {
                    lastDirection = "Up";
                }
                else if (movementDirection.y < 0)
                {
                    lastDirection = "Down";
                }
                else                             // Prioritize Up Down first
                {
                    if (movementDirection.x < 0)
                    {
                        lastDirection = "Left";
                    }
                    else if (movementDirection.x > 0)
                    {
                        lastDirection = "Right";
                    }
                }
                AnimationHandler();
            }
            else
            {
                moving = false;
                animator.SetBool("Moving", false);

            }
        }
        else
        {
            // animator.SetFloat("Speed", 0);
            rb.velocity = Vector2.zero;
            Debug.Log("cannot move");
            moving = false;
            AnimationHandler();
        }
    }

    // Magic happens here
    private void AnimationHandler()
    {
        if (moving)                                                     // if "moving" is true then animate 4 cardinal direction
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        else
        {
            
            if (lastDirection == "Up")
            {
                animator.SetFloat("Vertical", 1);
            }
            else if (lastDirection == "Down")
            {
                animator.SetFloat("Vertical", -1);
            }
            else if (lastDirection == "Left")
            {
                animator.SetFloat("Horizontal", -1);
            }
            else if (lastDirection == "Right")
            {
                animator.SetFloat("Horizontal", 1);
            }
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

