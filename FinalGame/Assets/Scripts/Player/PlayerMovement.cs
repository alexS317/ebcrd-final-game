using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Animator animator;

    private Vector3 _moveBy;
    private Rigidbody _rb;
    private bool _isRunning;
    private bool _isJumpingOrFalling;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    // Physics-based jump
    void OnJump(InputValue input)
    {
        if (_isJumpingOrFalling) return;
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    void Move()
    {
        _isJumpingOrFalling = _rb.velocity.y < -.035 || _rb.velocity.y > 0.00001;
        
        if (_moveBy == Vector3.zero) _isRunning = false;
        else _isRunning = true;
        
        animator.SetBool("run", _isRunning);
        animator.SetBool("jump", _isJumpingOrFalling);
        
        // Transform-based movement
        transform.Translate(_moveBy * (speed * Time.deltaTime));
    }
}