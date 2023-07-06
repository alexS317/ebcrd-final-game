using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackDamage = 1;

    private void OnCollisionEnter(Collision other)
    {
        // Decrease player health if player collides with enemy
        if(other.gameObject.CompareTag("Player")) GlobalStorage.Instance.DecreasePlayerHealth(attackDamage);
    }
}
