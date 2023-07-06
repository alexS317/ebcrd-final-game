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
        // Set start and target position
        _originalStartPos = transform.position;
        _originalTargetPos = _originalStartPos + movementDistance;
        ChangeMovementDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // Linear movement
    void Move()
    {
        if (_passedTime >= timeForMovement) ChangeMovementDirection();

        // Move linearly between positions
        transform.position = Vector3.Lerp(_currentStartPos, _currentTargetPos, _passedTime / timeForMovement);
        _passedTime += Time.deltaTime;
        
        transform.Rotate(Vector3.up, rotationSpeed);    // Object rotates around its own axis
    }

    // If the movement in one direction has been completed, the direction changes
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

        _passedTime = 0;    // Reset passed time
        _movingForward = !_movingForward;   // Switch condition for movement direction
    }
}