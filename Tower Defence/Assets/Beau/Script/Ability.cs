using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ability : MonoBehaviour
{
    public int freezeTime;
    public float fireRateTimesNumber, fireRateIncreaseTime;

    public GameObject enemyHolder, towerHolder;

    public ShopScript shopScript;

    private void Update()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            if(shopScript.numFirerate > 0)
            {
                shopScript.numFirerate--;
                StartCoroutine(IncreaseFireRate());
            }
        }
        if (Input.GetButtonDown("Ability2"))
        {
            if (shopScript.numFreeze > 0)
            {
                shopScript.numFreeze--;
                StartCoroutine(FreezeEnemies());
            }
        }
        if (Input.GetButtonDown("Ability3"))
        {
            if (shopScript.numNuke > 0)
            {

            }
        }
        if (Input.GetButtonDown("Ability4"))
        {
            if (shopScript.numSpike > 0)
            {

            }
        }
    }
    IEnumerator IncreaseFireRate()
    {
        foreach (Transform child in towerHolder.transform)
        {
            child.GetComponent<TurretRepair>().turretScript.fireRate *= fireRateTimesNumber;
        }
        yield return new WaitForSeconds(fireRateIncreaseTime);
        foreach (Transform child in towerHolder.transform)
        {
            child.GetComponent<TurretRepair>().turretScript.fireRate = child.GetComponent<TurretRepair>().turretScript.standardFireRate;
        }
    }
    IEnumerator FreezeEnemies()
    {
        foreach (Transform child in enemyHolder.transform)
        {
            child.GetComponent<NavMeshAgent>().speed = child.GetComponent<Enemy>().walkingSpeed /= 2;
        }
        yield return new WaitForSeconds(freezeTime);
        foreach (Transform child in enemyHolder.transform)
        {
            child.GetComponent<NavMeshAgent>().speed = child.GetComponent<Enemy>().walkingSpeed;
        }
    }
}
