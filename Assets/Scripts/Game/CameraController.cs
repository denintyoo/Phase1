using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y,  transform.position.z);

        if(transform.position != target.position)
        {
            float targetx = Mathf.Clamp(target.position.x,minPosition.x, maxPosition.x);

            float targety = Mathf.Clamp(target.position.y,minPosition.y, maxPosition.y);


            Vector3 targetPosition = new Vector3(targetx, targety, transform.position.z);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

}
