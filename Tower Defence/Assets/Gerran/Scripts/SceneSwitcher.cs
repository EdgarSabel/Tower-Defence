using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI text;

    public AudioSource clickButton, hoverButton;
    public void Level1()
    {
        StartCoroutine(LoadSceneEnumerator());
    }
    IEnumerator LoadSceneEnumerator()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("BeauScene");
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
    public void Level2()
    {
        SceneManager.LoadScene("MapScene");
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
    public void ClickButton()
    {
        clickButton.Play();
    }
    public void HoverButton()
    {
        hoverButton.Play();
    }
}
