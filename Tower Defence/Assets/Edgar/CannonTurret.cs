using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurret : Turret
{
    public GameObject projectile, currentProjectile, spawnPos;
    public float projectileSpeed;
    public override void Fire()
    {
        currentProjectile = Instantiate(projectile, spawnPos.transform.position, transform.rotation);
        currentProjectile.GetComponent<Projectile>().speed = projectileSpeed;
        currentProjectile.GetComponent<Projectile>().damage = damage;
    }
}
