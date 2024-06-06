using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Vector2 lastKnownPlayerPosition;
    public Transform playerTransform;
    public AnimationHandler animationHandler;
    private float switchThreshold = 0.5f;
    private float speed = 3f;
    public Vector3 thisNewVector = Vector3.zero;

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
        // Capture the player's coordinates using Vector2
        lastKnownPlayerPosition = playerTransform.position;
        // Debug.Log(lastKnownPlayerPosition);
        
        // Output the player's coordinates (for debugging purposes)
        Debug.Log("Player's Position: " + lastKnownPlayerPosition + " Chasing Now!");
        
        // Wait for 1 second
        yield return new WaitForSeconds(1f);
    }
}
