using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManeger : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSliderSound;
    public Slider volumeSliderMusic;
    public Slider volumeSliderMaster;

    public TMP_InputField inputBoxText;
    public Slider sensetivetySlider;

    public GameObject menuPanel, upgradePanel, hudPanel, cam, player;
    public GameObject[] panels;

    public GameObject mainCam, shopCam;

    // Start is called before the first frame update
    void Start()
    {
        cam.GetComponent<CamLook>().sensetivity = OptionsManeger.sensitivityStatic;
        inputBoxText.text = OptionsManeger.sensitivityStatic.ToString();
        sensetivetySlider.value = OptionsManeger.sensitivityStatic;

        volumeSliderMaster.value = OptionsManeger.masterSliderValue;
        volumeSliderMusic.value = OptionsManeger.musicSliderValue;
        volumeSliderSound.value = OptionsManeger.soundSliderValue;
    }
    public void Resume()
    {
        menuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.GetComponent<CamLook>().enabled = enabled;
        player.GetComponent<PlayerMovement>().enabled = enabled;
    }

    public void Back()
    {
        upgradePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        upgradePanel.GetComponent<DetectTurret>().turret = null;
    }
    public void ShopBack()
    { 
        shopCam.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = enabled;
        cam.GetComponent<CamLook>().enabled = enabled;

        hudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.GetComponent<CamLook>().canMove = true;
        //player.GetComponent<CamLook>().canMove = true;
    }

    public void SetMasterVol(float sliderValue)
    {
        OptionsManeger.masterSliderValue = sliderValue;
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVol(float sliderValue)
    {
        OptionsManeger.musicSliderValue = sliderValue;
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSoundVol(float sliderValue)
    {
        OptionsManeger.soundSliderValue = sliderValue;
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSensitivityFromNumber(string boxValue)
    {
        float usableValue = float.Parse(boxValue);
        if(usableValue >= 1 && usableValue <= 15)
        {
            sensetivetySlider.value = usableValue;
            cam.GetComponent<CamLook>().sensetivity = usableValue;
            OptionsManeger.sensitivityStatic = usableValue;
        }
        else if(usableValue < 1)
        {
            SetSensitivityFromNumber("1");
            print(usableValue);
            inputBoxText.text = "1";
        }
        else if(usableValue > 16)
        {
            SetSensitivityFromNumber("15");
            print(usableValue);
            inputBoxText.text = "15";
        }
    }
    public void SetSensitivity(float sliderValue)
    {
        inputBoxText.text = sliderValue.ToString();
        cam.GetComponent<CamLook>().sensetivity = sliderValue;
        OptionsManeger.sensitivityStatic = sliderValue;
    }

    #region Set Prefs
    private void SetPrefs(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
    private void SetPrefs(string key, string value)
    {
        PlayerPrefs.SetString(key, value);

    }
    private void SetPrefs(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);

    }
    private void SetPrefs(string key, bool value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));

    }
    #endregion
    
}
