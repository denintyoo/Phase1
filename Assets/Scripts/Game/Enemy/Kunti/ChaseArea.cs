using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseArea : MonoBehaviour
{
    public Kunti kunti;
    private CircleCollider2D chaseArea;


    void Awake()
    {
        chaseArea = GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is still within the chase range
            kunti.playerInRange = true;
            chaseArea.radius = 2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is exiting chase range
            kunti.playerInRange = false;
            chaseArea.radius = 1.25f;
        }
    }
}
