using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private float healthPoints = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalStorage.Instance.RestorePlayerHealth(healthPoints);
        
            Destroy(gameObject);
        }
    }
}
