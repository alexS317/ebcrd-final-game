using System;
using System.Collections;
using System.Collections.Generic;
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
        _weaponCollider.enabled = EnemyAnimEvents.IsHitting;

        DetectPlayer();
    }

    void DetectPlayer()
    {
        var ray = new Ray(new Vector3(transform.position.x, 1, transform.position.z), transform.forward);
        bool playerDetected = Physics.Raycast(ray, out var hitInfo, 10);
        Debug.DrawRay(new Vector3(transform.position.x, 1, transform.position.z), transform.forward * 10);
        Debug.Log("Detected");

        if (playerDetected && hitInfo.transform.CompareTag("Player"))
        {
            transform.Translate(Vector3.forward * (runningSpeed * Time.deltaTime));

            if (Vector3.Distance(transform.position, hitInfo.transform.position) <= 2f)
            {
                animator.SetTrigger("attack");
            }
        }
    }
}