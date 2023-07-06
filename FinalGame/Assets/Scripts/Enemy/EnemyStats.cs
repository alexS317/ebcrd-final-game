using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float enemyHealth;

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Debug.Log("Enemy health: " + enemyHealth);
        
        // If the health is 0, destroy the enemy and increase the counter
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            GlobalStorage.Instance.IncreaseEnemyCounter();
        }
    }
}
