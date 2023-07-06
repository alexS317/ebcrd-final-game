using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            var enemyStats = other.gameObject.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
    }
}
