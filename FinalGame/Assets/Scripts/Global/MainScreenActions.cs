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
        SceneManager.LoadSceneAsync("Level01");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
