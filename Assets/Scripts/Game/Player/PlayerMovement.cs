using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
        
       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Speed", movement.sqrMagnitude);

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
}
