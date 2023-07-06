using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStorage : MonoBehaviour
{
    public static GlobalStorage Instance;

    [field: SerializeField] public float PlayerHealth { get; private set; }
    [field: SerializeField] public int MaxAppleNr { get; private set; }
    public float MaxHealth { get; private set; }
    public int CoinScore { get; private set; }
    public int CurrentAppleNr { get; private set; }
    public int DefeatedEnemies { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        MaxHealth = PlayerHealth;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseScore()
    {
        CoinScore++;
        Debug.Log("Score: " + CoinScore);
    }

    public void SpawnApple()
    {
        CurrentAppleNr++;
    }

    public void ResetApples()
    {
        CurrentAppleNr = 0;
    }

    public void EnemyCounter()
    {
        DefeatedEnemies++;
    }

    public void DecreasePlayerHealth(float damage)
    {
        PlayerHealth -= damage;
        Debug.Log("Player health: " + PlayerHealth);

        // If the player has no more health, the game is lost
        if (PlayerHealth <= 0) SceneManager.LoadSceneAsync("GameOver");
    }

    public void RestorePlayerHealth(float healthPoints)
    {
        CurrentAppleNr--;
        PlayerHealth += healthPoints;
        if (PlayerHealth >= MaxHealth) PlayerHealth = MaxHealth;
        Debug.Log("Player health: " + PlayerHealth);
    }
}