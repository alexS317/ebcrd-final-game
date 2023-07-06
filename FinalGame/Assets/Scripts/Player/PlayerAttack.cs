using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    // [SerializeField] private float damage;

    [SerializeField] private GameObject weapon;
    
    [SerializeField] private Animator animator;

    private BoxCollider _weaponCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        _weaponCollider = weapon.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        _weaponCollider.enabled = AttackAnimEvents.IsHitting;
    }

    void OnAttack(InputValue input)
    {
        animator.SetTrigger("attack");
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         var enemyStats = other.gameObject.GetComponent<EnemyStats>();
    //         enemyStats.TakeDamage(damage);
    //     }
    // }
}
