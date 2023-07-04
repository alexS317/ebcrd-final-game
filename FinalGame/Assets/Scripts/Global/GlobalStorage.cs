using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStorage : MonoBehaviour
{
    public static GlobalStorage Instance;

    [field: SerializeField] public float PlayerHealth { get; private set; }
    public float MaxHealth { get; private set; }

    private int _coinScore;


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
        _coinScore++;
        Debug.Log("Score: " + _coinScore);
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
        PlayerHealth += healthPoints;
        if (PlayerHealth >= MaxHealth) PlayerHealth = MaxHealth;
        Debug.Log("Player health: " + PlayerHealth);
    }
}