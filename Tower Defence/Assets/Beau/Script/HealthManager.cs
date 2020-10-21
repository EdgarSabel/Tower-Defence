using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int waitForTextDisapear;
    int decreaseHealthNumber;
    public TextMeshProUGUI healthText, decreaseHealthText;
    public GameObject decreaseHealthObj, cam, player;

    public GameObject[] bgImages;
    public GameObject deathMenu;
    public bool dead;

    IEnumerator coroutine;

    private void Start()
    {
        UpdateHealthNumber();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            GetDamagedByEnemy(10000);
        }
        health = Mathf.Clamp(health, 0, 120);
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
    public void UpdateHealthNumber()
    {
        healthText.text = health.ToString();
        if(health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            cam.GetComponent<CamLook>().enabled = !enabled;
            player.GetComponent<PlayerMovement>().enabled = !enabled;
            Cursor.visible = true;

            if(dead == false)
            {
                dead = true;
                bgImages[Random.Range(0, bgImages.Length)].SetActive(true);
                deathMenu.SetActive(true);
            }
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
