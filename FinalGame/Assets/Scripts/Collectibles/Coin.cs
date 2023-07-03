using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GlobalStorage.Instance.IncreaseScore();
        
        Destroy(gameObject);
    }
}
