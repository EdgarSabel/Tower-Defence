using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("LoadingScreenLvl1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("quit");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
