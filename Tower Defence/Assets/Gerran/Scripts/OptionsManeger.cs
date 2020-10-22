using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsManeger : MonoBehaviour
{
    public Slider musicVolumeSlider, soundVolumeSlider, masterVolumeSlider, sensitivitySlider;
    public TMP_InputField inputBoxText;
    public static float sensitivityStatic, masterSliderValue, musicSliderValue, soundSliderValue;
    public AudioMixer mixer;
    public GameObject playercam;
    public GameObject[] panels;
    void Start()
    {
        masterSliderValue = PlayerPrefs.GetFloat("Master");
        musicSliderValue = PlayerPrefs.GetFloat("Music");
        soundSliderValue = PlayerPrefs.GetFloat("Sound");
        sensitivityStatic = PlayerPrefs.GetFloat("Sens");
        if (sensitivityStatic == 0)
        {
            sensitivityStatic = 4;
        }

        if(masterSliderValue == 0)
        {
            masterSliderValue = .5f;
        }
        if(musicSliderValue == 0)
        {
            musicSliderValue = .5f;
        }
        if(soundSliderValue == 0)
        {
            soundSliderValue = .5f;
        }
        print(sensitivityStatic);
        SetMasterVol(masterSliderValue);
        SetMusicVol(musicSliderValue);
        SetSoundVol(soundSliderValue);
        SetSensitivity(sensitivityStatic);
        SetSensitivityFromNumber(sensitivityStatic.ToString());
        gameObject.SetActive(false);
    }
    public void SetMasterVol(float sliderValue)
    {
        masterSliderValue = sliderValue;
        masterVolumeSlider.value = sliderValue;
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVol(float sliderValue)
    {
        musicSliderValue = sliderValue;
        musicVolumeSlider.value = sliderValue;
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSoundVol(float sliderValue)
    {
        soundSliderValue = sliderValue;
        soundVolumeSlider.value = sliderValue;
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSensitivityFromNumber(string boxValue)
    {
        float usableValue = float.Parse(boxValue);
        if (usableValue >= 1 && usableValue <= 15)
        {
            sensitivitySlider.value = usableValue;
            sensitivityStatic = usableValue;
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
        sensitivityStatic = sliderValue;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
