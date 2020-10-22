using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("HighScore").ToString("F0");
    }
}
