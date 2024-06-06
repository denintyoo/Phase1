using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject hitbox;
    private PolygonCollider2D hitboxCollider;
    public Chase chase;
    private float attackCooldown;
    private bool isAttacking = false;
    float distance = 0f;
    
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

    public void DoAttack()
    {
        if (!isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    public void PositionHitbox(Vector2 direction)
    {
        Vector2 targetDirection = Vector2.zero;
        targetDirection = Vector2.left * distance;
    }

    public void colliderOn()
    {
        hitboxCollider.enabled = true;
    }
    public void colliderOff()
    {
        hitboxCollider.enabled = false;
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;
        // Animation here
        // Debug.Log($"Attacking for {playerStats.AttackCooldown}");

        animator.SetTrigger("Attack");
        PositionHitbox(chase.thisNewVector);

        // Attack Speed Cooldown
        yield return new WaitForSeconds(attackCooldown);
        // Use Animation Event to flash hitbox
        isAttacking = false;

        // Debug.Log("Attack finished.");
    }
}
