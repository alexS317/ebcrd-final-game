using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStorage : MonoBehaviour
{
    public static GlobalStorage Instance;

    [field: SerializeField] public float PlayerHealth { get; private set; }

    private int coinScore;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        maxHealth = PlayerHealth;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseScore()
    {
        coinScore++;
        Debug.Log("Score: " + coinScore);
    }

    public void DecreasePlayerHealth(float damage)
    {
        PlayerHealth -= damage;
        Debug.Log("Player health: " + PlayerHealth);
    }

    public void RestorePlayerHealth(float healthPoints)
    {
        PlayerHealth += healthPoints;
        if (PlayerHealth >= maxHealth) PlayerHealth = maxHealth;
        Debug.Log("Player health: " + PlayerHealth);
    }
}