using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Kunti : MonoBehaviour
{
    public GameObject chaseStartHitbox;
    [SerializeField] public bool playerInRange;
    [SerializeField] public Coroutine capturePlayerPosition;
    public Chase chase;
    public Idle idle;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInRange)
        {
            StartCoroutine(chase.CapturePlayerPositionRoutine());
            chase.ChaseState();
        }
    }
}
