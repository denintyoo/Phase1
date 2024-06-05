using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Player MainPlayerClass;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = MainPlayerClass.stats.Attack;


    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Enemy"))
        {
            Collision.SendMessage("TakeDamage", damage);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}