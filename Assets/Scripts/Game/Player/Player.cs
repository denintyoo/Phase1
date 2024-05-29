using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public PlayerHealth health;
    public PlayerMovement movement;
    public PlayerCombat combat;
    public PlayerStats stats;


    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.Init();
        }
    }
    private void Update()
    {
        movement.MovementHandler();
    }

    public void FixedUpdate()
    {
        movement.UpdatePosition(stats.speed);
    }
}