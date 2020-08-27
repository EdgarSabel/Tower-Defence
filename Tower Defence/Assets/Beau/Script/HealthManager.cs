using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public Text healthText;

    private void Start()
    {
        UpdateHealthNumber();
    }
    public void GetDamagedByEnemy(int dmg)
    {
        health -= dmg;
        UpdateHealthNumber();
    }
    void UpdateHealthNumber()
    {
        healthText.text = health.ToString() + " (Health)";
        if(health <= 0)
        {
            print("Death");
        }
    }
}
