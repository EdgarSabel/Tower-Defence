﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int damage, slot;
    public float fireRate, radius;
    public new SphereCollider collider;
    [HideInInspector] public GameObject target;
public float longestDist;
    [HideInInspector]public float standardFireRate;
    [HideInInspector] public float lastShotTime = float.MinValue;

    void Start()
    {
        collider.radius = radius;
        standardFireRate = fireRate;
    }

    void Update()
    {
        FindTarget();
    }
    public virtual void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform.GetComponent<Enemy>() != null)
            {
                if (hitCollider.transform.GetComponent<Enemy>().distTravel > longestDist)
                {
                    longestDist = hitCollider.transform.GetComponent<Enemy>().distTravel;
                    target = hitCollider.transform.gameObject;
                }
            }
        }
        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }

        if (target != null && Time.time > lastShotTime + (3.0f / fireRate))
        {
            lastShotTime = Time.time;
            Fire();
            WipeTarget();
        }
    }
    public void WipeTarget()
    {
        target = null;
        longestDist = 0;
    }
    public virtual void Fire()
    {
        target.GetComponent<Enemy>().GetDamage(damage, true);
    }
    private void OnTriggerExit(Collider other)
    {
        WipeTarget();
    }
}
