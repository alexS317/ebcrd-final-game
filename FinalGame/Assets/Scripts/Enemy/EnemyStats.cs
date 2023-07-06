using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float enemyHealth;

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Debug.Log("Enemy health: " + enemyHealth);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            GlobalStorage.Instance.EnemyCounter();
        }
    }
}
