using System;
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
    private bool _isGrounded;

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

    // Set _isGrounded bool
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = false;
    }

    // Movement input
    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    // Physics-based jump
    void OnJump(InputValue input)
    {
        if (!_isGrounded) return;   // Prevent jumping mid-air
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    void Move()
    {
        // Only run when there's movement input
        _isRunning = _moveBy != Vector3.zero;
        animator.SetBool("run", _isRunning);

        // Only set jump animation if the player is not standing on the ground
        animator.SetBool("jump", !_isGrounded);

        // Prevent the player from moving on their own along the forward vector when they're not running
        if (!_isRunning) return;

        TurnPlayerFigure(_moveBy);

        // Transform-based movement
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    // Turn the player figure in the according running direction
    void TurnPlayerFigure(Vector3 rotateVector)
    {
        // Get a vector with a magnitude of 1 (only direction is important)
        rotateVector = Vector3.Normalize(rotateVector);

        // Rotate player figure in the same direction as the camera
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        // Calculate the angle for the y rotation (between -90 and 90)
        float rotationY = 90 * rotateVector.x;  // rotateVector.x is for left/right

        // If rotateVector.z (for forward/backward) is negative, turn the player around
        if (rotateVector.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;    // Mirror the y rotation
        }

        transform.Rotate(0, rotationY, 0);  // Rotate the player
    }
}