using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActions : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void StartGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("GlobalStorage")); // Destroy storage from previous game
        SceneManager.LoadSceneAsync("Level01");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
