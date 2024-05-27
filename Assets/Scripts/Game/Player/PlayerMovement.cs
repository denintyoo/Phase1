using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private bool canMove = true;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (canMove) // If can move is true then enable moving components. Else? Don't move
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }

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

    // This is to stop the player movement if the player casting / attacking.
    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
