using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseArea : MonoBehaviour
{
    public Kunti kunti;
    private CircleCollider2D chaseArea;
    public LayerMask obstructionLayer;
    public GameObject player;


    void Awake()
    {
        chaseArea = GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update

    private bool IsObstructed()
    {
        Vector2 direction = player.transform.position - kunti.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector2.Distance(kunti.transform.position, player.transform.position), obstructionLayer);
        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !IsObstructed())
        {
            // Player is within chase range and not obstructed
            kunti.playerInRange = true;
            chaseArea.radius = 2f; // Alerted state, this is no longer initial detection hitbox. This is the entire detection area.
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
