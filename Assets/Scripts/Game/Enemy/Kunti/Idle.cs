using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Idle : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    public enum AnimationDirection
    {
        Left,
        Right
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private AnimationDirection GetRandomDirection()
    {
        // Get a random integer between 0 and 3 (inclusive)
        int randomIndex = Random.Range(0, 1);

        // Convert the random integer to an AnimationDirection enum value
        return (AnimationDirection)randomIndex;
    }

    public void IdleState()
    {
        animator.SetBool("Idle", true);
        // Assign a random animation direction
        AnimationDirection randomDirection = GetRandomDirection();

        // Set the animator parameter based on the random direction
        switch (randomDirection)
        {
            case AnimationDirection.Left:
                sr.flipX = true;
                break;
            case AnimationDirection.Right:
                sr.flipX = false;
                break;
        }
    }
}
