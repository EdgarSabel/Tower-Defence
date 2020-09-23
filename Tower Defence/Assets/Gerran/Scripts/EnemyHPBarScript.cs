using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBarScript : MonoBehaviour
{

    public GameObject enemyOBJ, slider;
    public Slider enemyHPBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHPBar.value = enemyOBJ.GetComponent<Enemy>().EnemyHealth;

        if(enemyOBJ.GetComponent<Enemy>().EnemyHealth <= 100)
        {
            slider.SetActive(true);
        }
    }
}
