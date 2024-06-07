using System;
using System.Collections;
using UnityEngine;

public class Kunti : MonoBehaviour
{
    public GameObject chaseStartHitbox;
    [SerializeField] public bool playerInRange;
    [SerializeField] public Coroutine capturePlayerPosition;
    public CapsuleCollider2D capsuleCollider2D;
    public Chase chase;
    public Idle idle;
    public JumlahMati jumlahMati;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        jumlahMati = UnityEngine.Object.FindObjectOfType<JumlahMati>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerInRange)
        {
            if (capturePlayerPosition == null)
            {
                capturePlayerPosition = StartCoroutine(chase.CapturePlayerPositionRoutine());
                idle.idleStop();
                Debug.Log("Player is in Range, Capturing player position...");
            }
        }
        else
        {   
            if (capturePlayerPosition != null)
            {
                StopCoroutine(capturePlayerPosition);
                capturePlayerPosition = null;
            }
        }

        if (!playerInRange && !chase.chasing)
        {
            idle.IdleState();
        }
        else
        {
            chase.chasing = true;
        }
    }

    public void TakeDamage(int damage)
    {
        jumlahMati.Jumlah++ ;
        Destroy(gameObject);
    }
}
