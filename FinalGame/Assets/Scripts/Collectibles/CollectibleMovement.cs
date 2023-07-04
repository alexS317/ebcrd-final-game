using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMovement : MonoBehaviour
{
    [SerializeField] private Vector3 movementDistance;

    [SerializeField] private float timeForMovement;

    [SerializeField] private float rotationSpeed;

    private Vector3 _originalStartPos;
    private Vector3 _originalTargetPos;
    private Vector3 _currentStartPos;
    private Vector3 _currentTargetPos;
    private float _passedTime;
    private bool _movingForward;

    // Start is called before the first frame update
    void Start()
    {
        _originalStartPos = transform.position;
        _originalTargetPos = _originalStartPos + movementDistance;
        ChangeMovementDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (_passedTime >= timeForMovement) ChangeMovementDirection();

        transform.position = Vector3.Lerp(_currentStartPos, _currentTargetPos, _passedTime / timeForMovement);
        _passedTime += Time.deltaTime;
        
        transform.Rotate(Vector3.up, rotationSpeed);
    }

    void ChangeMovementDirection()
    {
        if (_movingForward)
        {
            _currentStartPos = _originalStartPos;
            _currentTargetPos = _originalTargetPos;
        }
        else
        {
            _currentStartPos = _originalTargetPos;
            _currentTargetPos = _originalStartPos;
        }

        _passedTime = 0;
        _movingForward = !_movingForward;
    }
}