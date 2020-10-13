using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManeger : MonoBehaviour
{
    private const string MASTER_VOLUME_PREF = "master-volume" ;
    private const string MUSIC_VOLUME_PREF = "music-volume";
    private const string SOUND_VOLUME_PREF = "sound-volume";
    private const string SENSETIVETY_PREF = "Sensetivety";

    public AudioMixer mixer;
    public Slider volumeSliderSound;
    public Slider volumeSliderMusic;
    public Slider volumeSliderMaster;

    public TMP_InputField inputBoxText;
    public Slider sensetivetySlider;

    public GameObject menuPanel, upgradePanel, shopPanel, hudPanel, cam, player;


    // Start is called before the first frame update
    void Start()
    {
        //volumeSliderMaster.value = PlayerPrefs.GetFloat(MASTER_VOLUME_PREF, 1);
        //volumeSliderMusic.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_PREF, 1);
        //volumeSliderSound.value = PlayerPrefs.GetFloat(SOUND_VOLUME_PREF, 1);
        //sensetivetySlider.value = PlayerPrefs.GetFloat(SENSETIVETY_PREF, 1);

    }

    public void Update()
    {

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
        shopPanel.SetActive(false);
        hudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.GetComponent<CamLook>().canMove = true;
        //player.GetComponent<CamLook>().canMove = true;
    }

    public void SetMasterVol(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVol(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSoundVol(float sliderValue)
    {
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSensitivityFromNumber(string boxValue)
    {
        float usableValue = float.Parse(boxValue);
        if(usableValue >= 1 && usableValue <= 15)
        {
            sensetivetySlider.value = usableValue;
            cam.GetComponent<CamLook>().sensetivity = usableValue;
            print(cam.GetComponent<CamLook>().sensetivity);
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
        print(cam.GetComponent<CamLook>().sensetivity);
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
