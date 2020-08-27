using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    public float timer, addTimeToTimer;
    public Text  roundNumberText,timeBetweenRoundsText;
    public GameObject timerObj;

    public GameObject[] enemies;

    int roundNumber;

    private void Start()
    {
        timer = addTimeToTimer;
        timerObj.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SkipWaitForNewRound();
        }

        if(timer >= 1.00001f)
        {
            timer -= Time.deltaTime;
            timeBetweenRoundsText.text = "Next round in " + timer.ToString("F0");
        }
        else if(timer < 1)
        {
            timer = 1;
            timerObj.SetActive(false);
            StartNextRound();
        }
    }
    public void StartNextRound()
    {
        print("start round");
        roundNumber++;
        roundNumberText.text = "Round " + roundNumber.ToString();
        StartCoroutine(DoWave());
    }
    public void SkipWaitForNewRound()
    {
        timer = -1;
    }

    float spawnTimer;
    public GameObject spawnpoint;

    IEnumerator DoWave()
    {
        if(roundNumber == 1)
        {
            spawnTimer = 1;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 2)
        {
            spawnTimer = 1;
            for (int i = 0; i < 7; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if (roundNumber == 3)
        {
            spawnTimer = 1;
            for (int i = 0; i < 3; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
            Instantiate(enemies[1], spawnpoint.transform);
        }
        else if (roundNumber == 4)
        {
            spawnTimer = 1;
            Instantiate(enemies[1], spawnpoint.transform);
            yield return new WaitForSeconds(spawnTimer);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if (roundNumber == 5)
        {
            spawnTimer = 1;
            Instantiate(enemies[1], spawnpoint.transform);
            yield return new WaitForSeconds(spawnTimer);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
    }
}
