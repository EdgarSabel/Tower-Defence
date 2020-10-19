using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTurret : Turret
{
    public ParticleSystem boostParticle;
    public GameObject zap, currentZap, spawnPos;
    public float zapSpeed;
    public float[] zapDur;
    public override void Fire()
    {
        animTop.SetTrigger("Shoot");
        currentZap = Instantiate(zap, spawnPos.transform.position, transform.rotation);
        currentZap.GetComponent<Zap>().speed = zapSpeed;
        currentZap.GetComponent<Zap>().damage = damage;
        currentZap.GetComponent<Zap>().range = radius;
        currentZap.GetComponent<Zap>().zapDur = zapDur[turretLevel];
    }
}
