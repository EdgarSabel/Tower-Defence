using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTurret : Turret
{
    public GameObject zap, currentZap, spawnPos;
    public float zapSpeed;
    public override void Fire()
    {
        currentZap = Instantiate(zap, spawnPos.transform.position, transform.rotation);
        currentZap.GetComponent<Zap>().speed = zapSpeed;
        currentZap.GetComponent<Zap>().damage = damage;
        currentZap.GetComponent<Zap>().range = radius;
    }
}
