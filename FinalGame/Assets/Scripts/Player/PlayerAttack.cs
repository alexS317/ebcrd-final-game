using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
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
        _weaponCollider.enabled = PlayerAnimEvents.IsHitting;
    }

    void OnAttack(InputValue input)
    {
        animator.SetTrigger("attack");
    }
}
