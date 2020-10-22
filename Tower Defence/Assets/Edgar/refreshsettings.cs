using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refreshsettings : MonoBehaviour
{
    public GameObject optionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(true);
        //OptionsManeger.masterSliderValue = PlayerPrefs.GetFloat("Master");
        //OptionsManeger.musicSliderValue = PlayerPrefs.GetFloat("Music");
        //OptionsManeger.soundSliderValue = PlayerPrefs.GetFloat("Sound");
        //OptionsManeger.sensitivityStatic = PlayerPrefs.GetFloat("Sens");
    }
}
