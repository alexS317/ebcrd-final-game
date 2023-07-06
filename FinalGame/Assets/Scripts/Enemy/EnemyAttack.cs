using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float runningSpeed;

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
        _weaponCollider.enabled = EnemyAnimEvents.IsHitting;    // Set weapon collider based on play events
    }

    // Detect player within trigger collider
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            transform.LookAt(other.transform, Vector3.up);  // Turn towards player
            transform.Translate(Vector3.forward * (runningSpeed * Time.deltaTime)); // Move towards player

            // Start attack if the enemy's close enough to the player
            if (Vector3.Distance(transform.position, other.transform.position) <= 2f)
            {
                animator.SetTrigger("attack");
            }
        }
    }
}