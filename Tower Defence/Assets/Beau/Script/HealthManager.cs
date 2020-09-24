using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health, waitForTextDisapear;
    int decreaseHealthNumber;
    public Text healthText, decreaseHealthText;
    public GameObject decreaseHealthObj, cam, player;

    public GameObject deathMenu;

    IEnumerator coroutine;

    private void Start()
    {
        UpdateHealthNumber();
    }

    public void GetDamagedByEnemy(int dmg)
    {
        health -= dmg;

        decreaseHealthObj.SetActive(true);
        decreaseHealthNumber += dmg;
        UpdateDecreaseNumber();
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = ShowDecreaseHealth();
            StartCoroutine(coroutine);
        }
        else
        {
            coroutine = ShowDecreaseHealth();
            StartCoroutine(coroutine);
        }

        UpdateHealthNumber();
    }
    void UpdateHealthNumber()
    {
        healthText.text = health.ToString() + " (Health)";
        if(health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            cam.GetComponent<CamLook>().enabled = !enabled;
            player.GetComponent<PlayerMovement>().enabled = !enabled;
            Cursor.visible = true;

            Time.timeScale = 0;
            deathMenu.SetActive(true);
        }
    }
    void UpdateDecreaseNumber()
    {
        decreaseHealthText.text = "-" + decreaseHealthNumber.ToString();
    }
    IEnumerator ShowDecreaseHealth()
    {
        yield return new WaitForSeconds(waitForTextDisapear);
        decreaseHealthObj.SetActive(false);
        decreaseHealthNumber = 0;
        UpdateDecreaseNumber();
    }
}
