using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Idle : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void idleStop()
    {
        animator.SetBool("Idle", false);
    }

    public void IdleState()
    {
        animator.SetBool("Idle", true);
    }
}
