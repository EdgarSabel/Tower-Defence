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

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        masterSliderValue = PlayerPrefs.GetFloat("Master");
        musicSliderValue = PlayerPrefs.GetFloat("Music");
        soundSliderValue = PlayerPrefs.GetFloat("Sound");
        sensitivityStatic = PlayerPrefs.GetFloat("Sens");
        
        if (sensitivityStatic == 0)
        {
            sensitivityStatic = 7;
        }
        inputBoxText.text = sensitivityStatic.ToString();
        sensitivitySlider.value = sensitivityStatic;

        if(masterSliderValue == 0)
        {
            masterSliderValue = 1;
        }
        if(musicSliderValue == 0)
        {
            musicSliderValue = 1;
        }
        if(soundSliderValue == 0)
        {
            soundSliderValue = 1;
        }
        masterVolumeSlider.value = masterSliderValue;
        musicVolumeSlider.value = musicSliderValue;
        soundVolumeSlider.value = soundSliderValue;
    }

    public void SetMasterVol(float sliderValue)
    {
        masterSliderValue = sliderValue;
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVol(float sliderValue)
    {
        musicSliderValue = sliderValue;
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSoundVol(float sliderValue)
    {
        soundSliderValue = sliderValue;
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
