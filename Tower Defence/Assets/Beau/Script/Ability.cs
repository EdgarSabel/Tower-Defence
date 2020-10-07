using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Ability : MonoBehaviour
{
    public float fireRateTimesNumber, fireRateIncreaseTime;
    public int freezeTime;
    public int explosionDmg;

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
                FreezeEnemies();
            }
        }
        if (Input.GetButtonDown("Ability3"))
        {
            if (shopScript.numNuke > 0)
            {
                shopScript.numNuke--;
                NukeAllEnemies();
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
        print("use fire rate increase");
        foreach (Transform child in towerHolder.transform)
        {
            child.GetComponent<TurretRepair>().turretScript.fireRate *= fireRateTimesNumber;
            child.GetComponent<TurretRepair>().boostParticles.Play();
        }
        yield return new WaitForSeconds(fireRateIncreaseTime);
        foreach (Transform child in towerHolder.transform)
        {
            child.GetComponent<TurretRepair>().turretScript.fireRate = child.GetComponent<TurretRepair>().turretScript.standardFireRate;
            child.GetComponent<TurretRepair>().boostParticles.Stop();
        }
    }
    void FreezeEnemies()
    {
        print("use freeze");
        foreach (Transform child in enemyHolder.transform)
        {
            child.GetComponent<Enemy>().FreezeAbil(freezeTime);
        }
    }
    void NukeAllEnemies()
    {
        print("use nuke");
        foreach (Transform child in enemyHolder.transform)
        {
            child.GetComponent<Enemy>().EnemyHealth -= explosionDmg;
        }
    }
}
