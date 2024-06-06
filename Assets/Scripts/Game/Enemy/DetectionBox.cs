using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public event Action<bool> PlayerDetected = delegate { };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerDetected.Invoke(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDetected.Invoke(false);

        }
    }
}
