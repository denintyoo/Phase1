using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimateMoving(Vector2 chaseDirection)
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Chasing", true);
        animator.SetFloat("Horizontal", chaseDirection.x);
        animator.SetFloat("Vertical", chaseDirection.y);
    }
}
