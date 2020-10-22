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
    public int waitTimeForNextRound, lvlNum;
    public GameObject playerManager;
    public int infEnemieIncrease;
    public Wave[] waves;
    public Sounds sounds;
    public VoiceLines voiceLinesScript;
    public AbilityCooldown nukeCooldown;

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
        DoVoiceLine(1);
        playerManager.GetComponent<MoneyManager>().GetMoney(moneyNumber);
        allEnemiesAreSpawned = false;
        WaitForNextRound();
        canSkip = true;
    }
    IEnumerator StartNewRound()
    {
        timerObj.SetActive(false);
        roundNumber++;
        nukeCooldown.ResetAbilCover();
        DoVoiceLine(0);
        sounds.startRoundSound.Play();
        UpdateRoundNumber();

        if(roundNumber == lvlNum)
        {
            bool val = true;
            PlayerPrefs.SetInt("PropName", val ? 1 : 0);
            PlayerPrefs.Save();
        }

        if (roundNumber < waves.Length)
        {
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
        }
        else
        {
            for (int i = 0; i < waves[waves.Length - 1].enemies.Length; i++)
            {
                waves[waves.Length - 1].enemies[i].amount += infEnemieIncrease;
            }
            for (int i = 0; i < waves[waves.Length - 1].enemies.Length; i++)
            {
                moneyNumber = waves[waves.Length - 1].moneyToGet;
                for (int o = 0; o < waves[waves.Length - 1].enemies[i].amount; o++)
                {
                    RandomSpawnPoint();
                    Instantiate(enemyPrefabs[waves[waves.Length - 1].enemies[i].enemyType], wantedSpawnPoint.transform.position, wantedSpawnPoint.transform.rotation, enemyObj.transform);
                    yield return new WaitForSeconds(waves[waves.Length - 1].enemies[i].rate);
                }
            }
        }
        allEnemiesAreSpawned = true;
    }
    public void DoVoiceLine(int beginOrEndRound)
    {
        if(beginOrEndRound == 0)
        {
            if (roundNumber == 2)
            {
                voiceLinesScript.SelectAudio(0);
            }
        }
        else if(beginOrEndRound == 1)
        { 
            if(roundNumber == 5)
            {
                voiceLinesScript.SelectAudio(1);
            }
        }
    }
}