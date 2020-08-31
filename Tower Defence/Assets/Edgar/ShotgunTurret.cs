using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTurret : Turret
{
    public GameObject projectile;
    public float offset;
    public override void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0f, offset, 0f));
        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0f, -offset, 0f));
    }
}
