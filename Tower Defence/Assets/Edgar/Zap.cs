﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : MonoBehaviour
{
    public float speed, range;
    public int damage;
    public GameObject closestEnemy, currentEnemy,lastEnemy, veryLastEnemy;
    // Start is called before the first frame update
    void Start()
    {
        UpdateZap();
    }

    // Update is called once per frame
    void Update()
    {
        if (closestEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);
            if (transform.position == closestEnemy.transform.position)
            {
                closestEnemy.GetComponent<Enemy>().GetDamage(damage, true);
                if (closestEnemy.GetComponent<Enemy>().isZapped == false)
                {
                    closestEnemy.GetComponent<Enemy>().isZapped = true;
                }
                if (veryLastEnemy != null)
                {
                    Destroy(gameObject);   
                }
                veryLastEnemy = lastEnemy;
                lastEnemy = currentEnemy;
                currentEnemy = closestEnemy;
                closestEnemy = null;
                UpdateZap();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateZap()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Enemy>() != null && lastEnemy != hitCollider.transform.gameObject && currentEnemy != hitCollider.transform.gameObject)
            {
                if (closestEnemy != null)
                {
                    if (Vector3.Distance(hitCollider.transform.position, transform.position) < Vector3.Distance(closestEnemy.transform.position, transform.position))
                    {
                        closestEnemy = hitCollider.gameObject;
                    }
                }
                else
                {
                    closestEnemy = hitCollider.gameObject;
                }
            }
        }
    }
}