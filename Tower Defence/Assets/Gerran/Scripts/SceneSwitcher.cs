using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject loadingScreen, turretloadout, menu, levelSelect;
    //public OptionsManeger optionManager;
    public Slider slider;
    public TextMeshProUGUI text;
    public bool val, lvl2;
    public AudioSource clickButton, hoverButton;
    public void Level1()
    {
        StartCoroutine(LoadSceneEnumerator());
    }
    public void Level1Plus()
    {
        if (val == true)
        {
            lvl2 = false;
            turretloadout.SetActive(true);
            menu.SetActive(false);
            levelSelect.SetActive(false);
        }
        else
        {
            StartCoroutine(LoadSceneEnumerator());
        }
    }

    IEnumerator LoadSceneEnumerator()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("BeauScene");
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = (progress * 100f).ToString("F0");
            yield return null;
        }
    }
    public void start()
    {
        val = PlayerPrefs.GetInt("PropName") == 1 ? true : false;
        if (lvl2 == true)
        {
            SceneManager.LoadScene("MapScene");
        }
        else if(lvl2 == false)
        {
            StartCoroutine(LoadSceneEnumerator());
        }
    }

    public void Level2Plus()
    {
        if (val == true)
        {
            lvl2 = true;
            turretloadout.SetActive(true);
            levelSelect.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("MapScene");
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.SetFloat("Master", OptionsManeger.masterSliderValue);
        PlayerPrefs.SetFloat("Music", OptionsManeger.musicSliderValue);
        PlayerPrefs.SetFloat("Sound", OptionsManeger.soundSliderValue);
        PlayerPrefs.SetFloat("Sens", OptionsManeger.sensitivityStatic);
        Application.Quit();
        print("quit");
    }
    public void MainMenu()
    {
        PlayerPrefs.SetFloat("Master", OptionsManeger.masterSliderValue);
        PlayerPrefs.SetFloat("Music", OptionsManeger.musicSliderValue);
        PlayerPrefs.SetFloat("Sound", OptionsManeger.soundSliderValue);
        PlayerPrefs.SetFloat("Sens", OptionsManeger.sensitivityStatic);
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
