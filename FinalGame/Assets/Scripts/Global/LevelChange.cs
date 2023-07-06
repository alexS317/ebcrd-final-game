using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private int coinsToWin;
    [SerializeField] private string levelName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (coinsToWin == GlobalStorage.Instance.CoinScore)
            {
                SceneManager.LoadSceneAsync(levelName);
                GlobalStorage.Instance.ResetAppleCounter(); // Reset apple counter for new level
            }
            else Debug.Log("I need to find more coins!");
        }
    }
}