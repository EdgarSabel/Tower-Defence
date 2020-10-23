using System;
using UnityEngine;

public class KillOnFall : MonoBehaviour
{
    public GameObject playerObj, spawnLoc;
    public HealthManager hpManagerScript;
    public int dmgOnFall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hpManagerScript.health >= 25)
            {
                playerObj.transform.position = spawnLoc.transform.position;
                hpManagerScript.GetDamagedByEnemy(dmgOnFall);
            }
            else if (hpManagerScript.health > 5 && hpManagerScript.health < 25)
            {
                int i = hpManagerScript.health;
                i -= 5;
                hpManagerScript.GetDamagedByEnemy(i);
            }
            playerObj.transform.position = spawnLoc.transform.position;
        }
    }
}
