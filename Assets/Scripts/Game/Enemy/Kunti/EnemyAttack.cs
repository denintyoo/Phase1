using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject hitbox;
    private PolygonCollider2D hitboxCollider;
    
    void Awake ()
    {
        animator = GetComponent<Animator>();
        hitboxCollider = GetComponent<PolygonCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
