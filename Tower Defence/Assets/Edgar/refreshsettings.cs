using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refreshsettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OptionsManeger.masterSliderValue = PlayerPrefs.GetFloat("Master");
        OptionsManeger.musicSliderValue = PlayerPrefs.GetFloat("Music");
        OptionsManeger.soundSliderValue = PlayerPrefs.GetFloat("Sound");
        OptionsManeger.sensitivityStatic = PlayerPrefs.GetFloat("Sens");
    }
}
