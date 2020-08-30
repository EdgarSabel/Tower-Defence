using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpiderUsable : MonoBehaviour
{
    public int speed, waitTimeBeforeWalking, waitTimeBeforeExplosion, explosionDelay, implodingNumber;
    public float enlargementNumber;

    bool move, expanding, imploding;
    GameObject target;
    GameObject spawnPoint;
    float desiredTargetRange, rangeWithTargetNew;

    private void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        StartCoroutine(WaitBeforeWalking());
    }
    private void Update()
    {
        if(move == true)
        {
            transform.LookAt(new Vector3(target.transform.position.x, 0, target.transform.position.z));
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(expanding == true)
        {
            transform.localScale += new Vector3(transform.localScale.x * enlargementNumber * Time.deltaTime, transform.localScale.y * enlargementNumber * Time.deltaTime, transform.localScale.z * enlargementNumber * Time.deltaTime);
            transform.Translate(0, transform.localScale.y * enlargementNumber * Time.deltaTime, 0);
        }
        if(imploding == true)
        {
            transform.localScale -= new Vector3(transform.localScale.x * implodingNumber * Time.deltaTime, transform.localScale.y * implodingNumber * Time.deltaTime, transform.localScale.z * implodingNumber * Time.deltaTime);
            transform.Translate(0, transform.localScale.y * -implodingNumber * Time.deltaTime, 0);
        }
    }
    void GetTarget()
    {
        foreach(Transform child in spawnPoint.transform)
        {
            rangeWithTargetNew = Vector3.Distance(transform.position, child.transform.position);

            if(desiredTargetRange != 0)
            {
                if(rangeWithTargetNew <= desiredTargetRange)
                {
                    desiredTargetRange = rangeWithTargetNew;
                    if(child.GetComponent<Enemy>().isFlying != true)
                    {
                        target = child.gameObject;
                    }
                }
            }
            else
            {
                desiredTargetRange = rangeWithTargetNew;
                if (child.GetComponent<Enemy>().isFlying != true)
                {
                    target = child.gameObject;
                }
            }
        }
        move = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            move = false;
            GetComponent<Collider>().enabled = !enabled;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(WaitToExpand());
        }
    }
    IEnumerator WaitBeforeWalking()
    {
        yield return new WaitForSeconds(waitTimeBeforeWalking);
        GetTarget();
    }
    IEnumerator WaitToExpand()
    {
        expanding = true;
        yield return new WaitForSeconds(explosionDelay);
        expanding = false;
        imploding = true;
        StartCoroutine(WaitToExplode());
    }
    IEnumerator WaitToExplode()
    {
        yield return new WaitForSeconds(waitTimeBeforeExplosion);
        print("Explode");
        Destroy(gameObject);
    }
}
