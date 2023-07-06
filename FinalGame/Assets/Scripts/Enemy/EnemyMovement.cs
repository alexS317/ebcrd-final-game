using System.Collections;
using System.Collections.Generic;
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
    
    void ChangeTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        Vector3 targetPosition = transform.position + randomDirection;

        if (NavMesh.SamplePosition(targetPosition, out var hit, radius, 1))
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
    }
}