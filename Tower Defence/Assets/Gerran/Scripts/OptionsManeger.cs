using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsManeger : MonoBehaviour
{
    public Slider musicVolumeSlider, soundVolumeSlider, masterVolumeSlider, sensitivitySlider;
    public TMP_InputField inputBoxText;
    public AudioMixer mixer;
    public GameObject playercam;

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
        if (usableValue >= 1 && usableValue <= 15)
        {
            sensitivitySlider.value = usableValue;
            playercam.GetComponent<CamLook>().sensetivity = usableValue;
            print(playercam.GetComponent<CamLook>().sensetivity);
        }
        else if (usableValue < 1)
        {
            SetSensitivityFromNumber("1");
            print(usableValue);
            inputBoxText.text = "1";
        }
        else if (usableValue > 16)
        {
            SetSensitivityFromNumber("15");
            print(usableValue);
            inputBoxText.text = "15";
        }
    }
    public void SetSensitivity(float sliderValue)
    {
        inputBoxText.text = sliderValue.ToString();
        playercam.GetComponent<CamLook>().sensetivity = sliderValue;
        print(playercam.GetComponent<CamLook>().sensetivity);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
