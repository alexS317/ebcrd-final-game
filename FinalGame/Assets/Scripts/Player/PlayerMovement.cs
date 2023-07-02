using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpForce = 5f;

    private Vector3 _moveBy;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Transform-based movement
        transform.Translate(_moveBy * (speed * Time.deltaTime));
    }

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    // Physics-based jump
    void OnJump(InputValue input)
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}