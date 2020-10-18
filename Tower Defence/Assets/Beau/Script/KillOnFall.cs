using System;
using UnityEngine;

public class KillOnFall : MonoBehaviour
{
    public GameObject playerObj, spawnLoc;
    public HealthManager hpManagerScript;
    public int dmgOnFall;
    private void OnTriggerEnter(Collider other)
    {
        playerObj.transform.position = spawnLoc.transform.position;
        hpManagerScript.GetDamagedByEnemy(dmgOnFall);
    }
}
