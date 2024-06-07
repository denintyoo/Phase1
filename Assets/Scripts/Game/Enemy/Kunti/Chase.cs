using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class Chase : MonoBehaviour
{
    
    private Vector2 lastKnownPlayerPosition;
    public Transform playerTransform;
    public AnimationHandler animationHandler;
    private float switchThreshold = 0.5f;
    private float speed = 3f;
    public Vector3 thisNewVector;
    public bool chasing = false;

    void Start()
    {
        // StartCoroutine(debugThisNewVector());
    }

    void FixedUpdate()
    {
        if (chasing == true)
        {
        // Keep chasing to last known target position. Only stopped if last known target is no longer updated and is close.
            float distanceToTarget = Vector3.Distance(transform.position, lastKnownPlayerPosition);
            if (distanceToTarget > 1f)
            {
                ChaseState();
            }
            else
            {
                chasing = false;
                animationHandler.chaseStop();
            }
        }
    }

    private void UpdateDirection() // Butuh Vector dari CapturePlayerPositionRoutine yaitu chaseTarget
    {
        float xDifference = Mathf.Abs(lastKnownPlayerPosition.x - transform.position.x);
        float yDifference = Mathf.Abs(lastKnownPlayerPosition.y - transform.position.y);

        if (Mathf.Abs(xDifference - yDifference) >= switchThreshold) // Check if the difference exceeds the threshold
        {
            if (xDifference >= yDifference)
            {
                // Set the direction to horizontal
                thisNewVector = new Vector3(lastKnownPlayerPosition.x - transform.position.x, 0f, 0f).normalized;
            }
            else
            {
                // Set the direction to vertical
                thisNewVector = new Vector3(0f, lastKnownPlayerPosition.y - transform.position.y, 0f).normalized;
            }
        }

    }

    public void ChaseState()
    {
        UpdateDirection();
        transform.position += thisNewVector * speed * Time.deltaTime;
        animationHandler.AnimateMoving(thisNewVector);
    }

    public IEnumerator CapturePlayerPositionRoutine()
    {
        while (true)
        {
            // Capture the player's coordinates using Vector2
            lastKnownPlayerPosition = playerTransform.position;
            // Debug.Log(lastKnownPlayerPosition);
            
            // Output the player's coordinates (for debugging purposes)
            
            // Wait for 1 second
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator debugThisNewVector()
    {
        while (true)
        {
        yield return new WaitForSeconds(2f);
        Debug.Log(thisNewVector);
        }
    }

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
}
