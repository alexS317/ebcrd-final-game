using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private int coinsToWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (coinsToWin == GlobalStorage.Instance.CoinScore)
            {
                SceneManager.LoadSceneAsync("Success");
            }
        }
    }
}