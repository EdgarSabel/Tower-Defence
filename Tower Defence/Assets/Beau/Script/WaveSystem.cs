using UnityEngine;
using System.Collections;
using TMPro;
using System.Threading;

public class WaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemies[] enemies;
        public int moneyToGet;
    }
    [System.Serializable]
    public class Enemies
    {
        public int enemyType;
        public int amount;
        public float rate;
    }
    [System.Serializable]
    public class Sounds
    {
        public AudioSource shopOpenedSound, startRoundSound;
    }
    public GameObject[] enemyPrefabs;
    public TextMeshProUGUI roundNumberText, nextRoundInText;
    public GameObject timerObj;
    public GameObject enemyObj;
    public GameObject[] spawnPoints;
    public int waitTimeForNextRound;
    public GameObject playerManager;
    public Wave[] waves;
    public Sounds sounds;

    float timer;
    GameObject wantedSpawnPoint;
    int roundNumber = -1, moneyNumber;
    bool allEnemiesAreSpawned, canSkip;

    IEnumerator coroutine;

    private void Start()
    {
        WaitForNextRound();
        canSkip = true;
    }
    private void Update()
    {
        if(enemyObj.transform.childCount == 0 && allEnemiesAreSpawned == true)
        {
            EndRound();
        }
        if (Input.GetButtonDown("SkipWave") && canSkip == true) 
        {
            canSkip = false;
            timer = 1;
            StartCoroutine(StartNewRound());
        }
        if(timer >= 1.00001)
        {
            timer -= Time.deltaTime;
            nextRoundInText.text = "Waiting " + timer.ToString("F0");
        }
        else if(timer <= 0.99999)
        {
            timer = 1;
            canSkip = false;
            StartCoroutine(StartNewRound());
        }
    }
    void UpdateRoundNumber()
    {
        roundNumberText.text = "Round " + (roundNumber + 1).ToString();
    }
    void RandomSpawnPoint()
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        wantedSpawnPoint = spawnPoints[randomNumber];
    }
    void WaitForNextRound()
    {
        timer = waitTimeForNextRound;
        timerObj.SetActive(true);
        canSkip = true;
    }
    void EndRound()
    {
        playerManager.GetComponent<MoneyManager>().GetMoney(moneyNumber);
        allEnemiesAreSpawned = false;
        WaitForNextRound();
        canSkip = true;
    }
    IEnumerator StartNewRound()
    {
        timerObj.SetActive(false);
        roundNumber++;
        UpdateRoundNumber();
        for (int i = 0; i < waves[roundNumber].enemies.Length; i++)
        {
            moneyNumber = waves[roundNumber].moneyToGet;
            for (int o = 0; o < waves[roundNumber].enemies[i].amount; o++)
            {
                RandomSpawnPoint();
                Instantiate(enemyPrefabs[waves[roundNumber].enemies[i].enemyType], wantedSpawnPoint.transform.position, wantedSpawnPoint.transform.rotation, enemyObj.transform);
                yield return new WaitForSeconds(waves[roundNumber].enemies[i].rate);
            }
        }
        allEnemiesAreSpawned = true;
    }
}