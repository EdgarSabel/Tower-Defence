using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ability : MonoBehaviour
{
    public bool damage, freeze, fireRate;

    public int dmgNumber;
    public int freezeTime;
    public float fireRateTimesNumber, fireRateIncreaseTime;

    public GameObject locationsObj, towersObj;
    GameObject[] enemies;

    public void UseAbility()
    {
        if(damage == true)
        {
            foreach (Transform child in locationsObj.transform)
            {
                child.GetComponent<Enemy>().GetDamage(dmgNumber, false);
            }
        }
        else if(freeze == true)
        {
            StartCoroutine(FreezeEnemies());
        }
        else if(fireRate == true)
        {
            StartCoroutine(IncreaseFireRate());
        }
        else
        {
            Debug.LogError("no ability selected");
        }
    }
    IEnumerator FreezeEnemies()
    {
        foreach (Transform child in locationsObj.transform)
        {
            child.GetComponent<NavMeshAgent>().speed = 0;
        }
        yield return new WaitForSeconds(freezeTime);
        foreach (Transform child in locationsObj.transform)
        {
            child.GetComponent<NavMeshAgent>().speed = child.GetComponent<Enemy>().walkingSpeed;
        }
    }
    IEnumerator IncreaseFireRate()
    {
        foreach (Transform child in towersObj.transform)
        {
            child.GetComponent<Turret>().fireRate *= fireRateTimesNumber;
        }
        yield return new WaitForSeconds(fireRateIncreaseTime);
        foreach (Transform child in towersObj.transform)
        {
            child.GetComponent<Turret>().fireRate = child.GetComponent<Turret>().standardFireRate;
        }
    }
}
