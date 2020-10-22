using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshPro highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "High score: " + PlayerPrefs.GetFloat("HighScore").ToString(); ;
    }
}
