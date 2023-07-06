using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float radius;
    
    private NavMeshAgent _navMeshAgent;
    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.velocity == Vector3.zero)
        {
            ChangeTargetPosition();
        }
        
        SetAnimation();
        transform.position = _navMeshAgent.nextPosition;
    }

    void SetAnimation()
    {
        _isMoving = _navMeshAgent.velocity != Vector3.zero;
        animator.SetBool("run", _isMoving);
    }
    
    // Find the next target position to go to
    void ChangeTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius; // Select a random direction within radius
        Vector3 targetPosition = transform.position + randomDirection;  // Set target position

        // If the nearest point is found, set the new destination
        if (NavMesh.SamplePosition(targetPosition, out var hit, radius, 1))
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
    }
}