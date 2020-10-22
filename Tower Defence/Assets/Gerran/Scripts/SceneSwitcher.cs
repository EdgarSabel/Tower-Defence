using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject loadingScreen, turretloadout, menu, fuckOff;
    //public OptionsManeger optionManager;
    public Slider slider;
    public TextMeshProUGUI text, turretText;
    public bool val, lvl2;
    public AudioSource clickButton, hoverButton;
    public Color color;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            print("in main scene");
            val = PlayerPrefs.GetInt("PropName") == 1 ? true : false;
            if(val == true)
            {
                turretText.color = color;
            }
        }
    }
    public void Level1()
    {
        StartCoroutine(LoadSceneEnumerator());
    }
    public void Level1Plus()
    {
        if (val == true)
        {
            turretloadout.SetActive(true);
            menu.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowFuckOff());
        }
    }
    IEnumerator ShowFuckOff()
    {
        fuckOff.SetActive(true);
        yield return new WaitForSeconds(3);
        fuckOff.SetActive(false);
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
    public void level2()
    {   
        SceneManager.LoadScene("MapScene");
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
