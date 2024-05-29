using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove = true;

    private Vector2 movement;

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void MovementHandler()
    {
        if (canMove) // If canMove is true then enable moving components. Else? Don't move
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = new Vector2(movement.x, movement.y).normalized;
            
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            rb.velocity = Vector2.zero;
            Debug.Log("cannot move");
            animator.SetFloat("Speed", 0);
        }

    }

    public void UpdatePosition(int moveSpeed)
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
        }
        else
        {
            rb.MovePosition(rb.position);
        }
    }

    // This is to stop the player movement if the player casting / attacking.
    public void SetCanMove(bool value)
    {
        canMove = value;
        Debug.Log($"set canmove to{canMove}");
    }
}

