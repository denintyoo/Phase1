using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    private Transform target;
    [SerializeField]
    public float speed;
    [SerializeField]
    //public float maxRange;
    //[SerializeField]
    //public float minRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        target = GameObject.FindFirstObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange)
        FollowPlayer();
      
    }

    public void FollowPlayer()
    {
        //animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveX", (target.position.x - transform.position.x));

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

}
