using TMPro;
using UnityEngine;

public class SuccessScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "You defeated " + GlobalStorage.Instance.DefeatedEnemyNr + " skeleton(s)!";
    }
}