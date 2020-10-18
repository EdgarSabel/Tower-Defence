using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBarScript : MonoBehaviour
{

    public GameObject enemyOBJ, slider;
    public Slider enemyHPBar;

    private void Start()
    {
        enemyHPBar.maxValue = enemyOBJ.GetComponent<Enemy>().EnemyHealth;
        slider.SetActive(false);
    }
    void Update()
    {
        if(enemyOBJ.GetComponent<Enemy>().EnemyHealth < enemyHPBar.maxValue)
        {
            slider.SetActive(true);
            enemyHPBar.value = enemyOBJ.GetComponent<Enemy>().EnemyHealth;
        }
    }
}
