using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Kunti : MonoBehaviour
{
    private Animator animator;
    public GameObject chaseStartHitbox;
    public GameObject chaseArea;
    private bool playerInRange;
    private Vector2 lastKnownPlayerPosition;
    private Transform chaseTarget;
    private Coroutine capturePlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Chase(Vector2 lastPlayerVector)
    {
    //    transform.position += Vector2 ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is still within the chase range
            playerInRange = true;
            capturePlayerPosition = StartCoroutine(CapturePlayerPositionRoutine());

        }
    }

    private IEnumerator CapturePlayerPositionRoutine()
    {
        // Capture the player's coordinates using Vector2
        lastKnownPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        // Output the player's coordinates (for debugging purposes)
        Debug.Log("Player's Position: " + lastKnownPlayerPosition + " Chasing Now!");
        
        // Wait for 1 second
        yield return new WaitForSeconds(1f);
    }
}
