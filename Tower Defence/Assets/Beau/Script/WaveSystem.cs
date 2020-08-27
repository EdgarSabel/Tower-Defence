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

    int roundNumber, randomMaxEnemyLevel;

    float spawnTimer;
    public GameObject spawnpoint;
    bool canSetTimer = false;

    private void Start()
    {
        SetBetweenRoundTimer();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SkipWaitForNewRound();
        }

        if(spawnpoint.transform.childCount == 0 && canSetTimer == true)
        {
            canSetTimer = false;
            SetBetweenRoundTimer();
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
        roundNumber++;
        roundNumberText.text = "Round " + roundNumber.ToString();
        StartCoroutine(DoWave());
    }
    public void SkipWaitForNewRound()
    {
        if(timerObj.activeSelf == true)
        {
            timer = -1;
        }
    }

    void SetBetweenRoundTimer()
    {
        timer = addTimeToTimer;
        timerObj.SetActive(true);
    }

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
            for (int i = 0; i < 3; i++)
            {
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if (roundNumber == 6)
        {
            spawnTimer = 1;
            randomMaxEnemyLevel = 3;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
            for (int i = 0; i < 5; i++)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 7)
        {
            spawnTimer = 1;
            randomMaxEnemyLevel = 3;
            for (int i = 0; i < 10; i++)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 8)
        {
            spawnTimer = 1;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[2], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 9)
        {
            spawnTimer = 1f;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
            spawnTimer = 0.2f;
            for (int i = 0; i < 7; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 10)
        {
            spawnTimer = 1f;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 11)
        {
            spawnTimer = .5f;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemies[2], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 12)
        {
            spawnTimer = .5f;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 3; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[2], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 13)
        {
            spawnTimer = .7f;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 2; i++)
            {
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[0], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(enemies[1], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        else if(roundNumber == 14)
        {
            spawnTimer = .7f;
            randomMaxEnemyLevel = 4;
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemies[2], spawnpoint.transform);
                yield return new WaitForSeconds(spawnTimer);
            }
            for (int i = 0; i < 15; i++)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(spawnTimer);
            }
        }
        canSetTimer = true;
    }
    void SpawnRandomEnemy()
    {
        int RandomNumber = Random.Range(0, randomMaxEnemyLevel);
        if(RandomNumber == 1)
        {
            Instantiate(enemies[0], spawnpoint.transform);
        }
        else if(RandomNumber == 2)
        {
            Instantiate(enemies[1], spawnpoint.transform);
        }
        else if(RandomNumber == 3)
        {
            Instantiate(enemies[2], spawnpoint.transform);
        }
    }
}
