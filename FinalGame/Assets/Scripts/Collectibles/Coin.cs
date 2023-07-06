using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalStorage.Instance.IncreaseScore();
        
            Destroy(gameObject); 
        }
    }
}
