using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemies[] enemies;
    }
    [System.Serializable]
    public class Enemies
    {
        public int enemyType;
        public int amount;
        public float rate;
    }
    public GameObject[] enemyPrefabs;
    public Text roundNumberText;
    public GameObject enemyObj;
    public GameObject[] spawnPoints;
    public int waitTimeForNextRound;
    public Wave[] waves;

    Vector3 wantedSpawnPoint;
    int roundNumber = -1;
    bool allEnemiesAreSpawned, canSkip;

    IEnumerator coroutine;

    private void Start()
    {
        coroutine = WaitForRound();
        StartCoroutine(coroutine);
        canSkip = true;
    }
    private void Update()
    {
        if(enemyObj.transform.childCount == 0 && allEnemiesAreSpawned == true)
        {
            allEnemiesAreSpawned = false;
            coroutine = WaitForRound();
            StartCoroutine(coroutine);
            canSkip = true;
        }
        if (Input.GetKeyDown(KeyCode.P) && canSkip == true) 
        {
            canSkip = false;
            StopCoroutine(coroutine);
            StartCoroutine(StartNewRound());
        }
    }
    void RandomSpawnPoint()
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        wantedSpawnPoint = spawnPoints[randomNumber].transform.position;
    }
    IEnumerator StartNewRound()
    {
        roundNumber++;
        for (int i = 0; i < waves[roundNumber].enemies.Length; i++)
        {
            for (int o = 0; o < waves[roundNumber].enemies[i].amount; o++)
            {
                RandomSpawnPoint();
                Instantiate(enemyPrefabs[waves[roundNumber].enemies[i].enemyType], wantedSpawnPoint, Quaternion.identity, enemyObj.transform);
                yield return new WaitForSeconds(waves[roundNumber].enemies[i].rate);
            }
        }
        allEnemiesAreSpawned = true;
    }
    IEnumerator WaitForRound()
    {
        yield return new WaitForSeconds(waitTimeForNextRound);
        StartCoroutine(StartNewRound());
        canSkip = false;
    }
}