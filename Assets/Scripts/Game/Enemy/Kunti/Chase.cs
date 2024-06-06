using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Vector2 lastKnownPlayerPosition;
    public Transform playerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChaseState() // Butuh Vector dari CapturePlayerPositionRoutine yaitu chaseTarget
    {
        Vector3 thisNewVector = Vector3.zero;
        float xDifference = Mathf.Abs(lastKnownPlayerPosition.x - transform.position.x);
        float yDifference = Mathf.Abs(lastKnownPlayerPosition.y - transform.position.y);
        
        if (xDifference >= yDifference)
        {
            thisNewVector = new Vector3(lastKnownPlayerPosition.x - transform.position.x, 0f, 0f).normalized * 2f * Time.deltaTime;
            transform.position += thisNewVector;
        }
        else if (xDifference < yDifference)
        {
            thisNewVector = new Vector3(0f, lastKnownPlayerPosition.y - transform.position.y, 0f).normalized * 2f * Time.deltaTime;
            transform.position += thisNewVector;
        }
        Debug.Log("Catch This " + thisNewVector);
    }

    public IEnumerator CapturePlayerPositionRoutine()
    {
        // Capture the player's coordinates using Vector2
        lastKnownPlayerPosition = playerTransform.position;
        Debug.Log(lastKnownPlayerPosition);
        
        // Output the player's coordinates (for debugging purposes)
        Debug.Log("Player's Position: " + lastKnownPlayerPosition + " Chasing Now!");
        
        // Wait for 1 second
        yield return new WaitForSeconds(1f);
    }
}
