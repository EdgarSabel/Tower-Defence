using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManeger : MonoBehaviour
{
    public Slider musicVolumeSlider, soundVolumeSlider, MasterVolumeSlider, SensitivitySlider;
    public AudioMixer mixer;
    public GameObject playercam, graphicsDropdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()
    {
        mixer.SetFloat("Music Volume", Mathf.Log10(musicVolumeSlider.value) * 20);
    }
    public void SetSoundVolume()
    {
        mixer.SetFloat("Sound Volume", Mathf.Log10(soundVolumeSlider.value) * 20);
    }
    public void SetMasterVolume()
    {
        mixer.SetFloat("Master Volume", Mathf.Log10(MasterVolumeSlider.value) * 20);
    }

    public void SensitivityChange()
    {
        playercam.GetComponent<CamLook>().sensetivity = SensitivitySlider.value * 100;
        print(SensitivitySlider);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
