using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManeger : MonoBehaviour
{
    private const string MASTER_VOLUME_PREF = "master-volume" ;
    private const string MUSIC_VOLUME_PREF = "music-volume";
    private const string SOUND_VOLUME_PREF = "sound-volume";
    private const string SENSETIVETY_PREF = "Sensetivety";

    public Slider volumeSliderSound;
    public Slider volumeSliderMusic;
    public Slider volumeSliderMaster;
    public Slider sensetivetySlider;

    public GameObject menuPanel, upgradePanel, shopPanel, hudPanel, cam, player;


    // Start is called before the first frame update
    void Start()
    {
        volumeSliderMaster.value = PlayerPrefs.GetFloat(MASTER_VOLUME_PREF, 1);
        volumeSliderMusic.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_PREF, 1);
        volumeSliderSound.value = PlayerPrefs.GetFloat(SOUND_VOLUME_PREF, 1);
        sensetivetySlider.value = PlayerPrefs.GetFloat(SENSETIVETY_PREF, 1);

    }

    public void Update()
    {

    }

    public void Resume()
    {
        menuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Back()
    {
        upgradePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ShopBack()
    {
        shopPanel.SetActive(false);
        hudPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.GetComponent<CamLook>().canMove = true;
        player.GetComponent<CamLook>().canMove = true;
    }



    public void OnChangeMasterVolume(float value)
    {
        SetPrefs(MASTER_VOLUME_PREF, value);
    }
    public void OnChangeSoundVolume(float value)
    {
        SetPrefs(SOUND_VOLUME_PREF, value);
    }
    public void OnChangeMusicVolume(float value)
    {
        SetPrefs(MUSIC_VOLUME_PREF, value);
    }
    public void OnChangeSensetivety(float value)
    {
        SetPrefs (SENSETIVETY_PREF, value);
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
