using System;
using System.Collections;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class SpiderUsable : MonoBehaviour
{
    public int speed, dmg;
    public int waitToWalk;

    public GameObject target;

    bool settingTarget;
    GameObject spawnPointEnemy;
    NavMeshAgent agent;

    float targetDist, newDist;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0;
        spawnPointEnemy = GameObject.Find("SpawnPoint");

        chooseTarget();
        StartCoroutine(WaitBeforeWalking());
    }
    private void Update()
    {
        if(settingTarget == true)
        {
            if(target != null)
            {
            agent.SetDestination(target.transform.position);
            }
            else
            {
                settingTarget = false;
                chooseTarget();
            }
        }
    }
    void chooseTarget()
    {
        foreach(Transform child in spawnPointEnemy.transform)
        {
            if(spawnPointEnemy.transform.childCount != 0)
            {
                newDist = Vector3.Distance(transform.position, child.transform.position);
                if (targetDist == 0)
                {
                    targetDist = newDist;
                    if(child.GetComponent<Enemy>().isFlying != true)
                    {
                    target = child.gameObject;
                    }
                }
                else
                {
                    if(newDist <= targetDist)
                    {
                        targetDist = Vector3.Distance(transform.position, child.transform.position);
                        if (child.GetComponent<Enemy>().isFlying != true)
                        {
                            target = child.gameObject;
                        }
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        settingTarget = true;
    }
    IEnumerator WaitBeforeWalking()
    {
        yield return new WaitForSeconds(waitToWalk);
        agent.speed = speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
