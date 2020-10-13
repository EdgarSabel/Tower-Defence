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

    public GameObject enemyHolder, towerHolder, cooldownRF, cooldownNuke, cooldownFreeze;

    public ShopScript shopScript;

    private void Update()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            if (cooldownRF.GetComponent<AbilityCooldown>().abilityImageCover.rectTransform.sizeDelta.y == 0)
            {
                if (shopScript.numFirerate > 0)
                {
                    shopScript.numFirerate--;
                    StartCoroutine(IncreaseFireRate());
                    cooldownRF.GetComponent<AbilityCooldown>().abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);

                }
            }
        }
        if (Input.GetButtonDown("Ability2"))
        {
            if (cooldownFreeze.GetComponent<AbilityCooldown>().abilityImageCover.rectTransform.sizeDelta.y == 0)
            {
                if (shopScript.numFreeze > 0)
                {
                    shopScript.numFreeze--;
                    FreezeEnemies();
                    cooldownFreeze.GetComponent<AbilityCooldown>().abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);

                }
            }
        }
        if (Input.GetButtonDown("Ability3"))
        {
            if (cooldownNuke.GetComponent<AbilityCooldown>().abilityImageCover.rectTransform.sizeDelta.y == 0)
            {
                if (shopScript.numNuke > 0)
                {
                    shopScript.numNuke--;
                    NukeAllEnemies();
                    cooldownNuke.GetComponent<AbilityCooldown>().abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);

                }
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
