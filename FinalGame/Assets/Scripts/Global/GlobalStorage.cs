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
    public int DefeatedEnemyNr { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        MaxHealth = PlayerHealth;   // Set max health

        DontDestroyOnLoad(gameObject);  // Keep object in other scenes
    }

    public void IncreaseScore()
    {
        CoinScore++;
        Debug.Log("Score: " + CoinScore);
    }

    public void SpawnAppleCounter()
    {
        CurrentAppleNr++;
    }

    public void ResetAppleCounter()
    {
        CurrentAppleNr = 0;
    }

    public void IncreaseEnemyCounter()
    {
        DefeatedEnemyNr++;
    }

    public void DecreasePlayerHealth(float damage)
    {
        PlayerHealth -= damage;
        Debug.Log("Player health: " + PlayerHealth);

        // If the player has no more health, the game is lost
        if (PlayerHealth <= 0) SceneManager.LoadSceneAsync("GameOver");
    }

    public void IncreasePlayerHealth(float healthPoints)
    {
        CurrentAppleNr--;
        PlayerHealth += healthPoints;
        Debug.Log("Player health: " + PlayerHealth);
        
        // Don't allow player health to get bigger than the initial value
        if (PlayerHealth >= MaxHealth) PlayerHealth = MaxHealth;
    }
}