using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuccessScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "You defeated " + GlobalStorage.Instance.DefeatedEnemies + " skeleton(s)!";
    }
}