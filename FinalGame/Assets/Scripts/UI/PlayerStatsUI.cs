using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private GameObject storageObj;

    [SerializeField] private Image healthBar;

    private GlobalStorage _storage;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get storage object to access player health
        _storage = storageObj.GetComponent<GlobalStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        // Scale player health according to health value
        healthBar.transform.localScale = new Vector3(_storage.PlayerHealth / _storage.maxHealth, 1, 1);
    }
}
