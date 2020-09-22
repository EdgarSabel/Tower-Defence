using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTurret : Turret
{
    public GameObject projectile, currentProjectile, spawnPos;
    public float projectileSpeed;
    public float offset;
    public override void Fire()
    {
        currentProjectile = Instantiate(projectile, spawnPos.transform.position, transform.rotation);
        currentProjectile.GetComponent<Projectile>().speed = projectileSpeed;
        currentProjectile.GetComponent<Projectile>().damage = damage;
        currentProjectile = Instantiate(projectile, spawnPos.transform.position, transform.rotation * Quaternion.Euler(0f, offset, 0f));
        currentProjectile.GetComponent<Projectile>().speed = projectileSpeed;
        currentProjectile.GetComponent<Projectile>().damage = damage;
        currentProjectile = Instantiate(projectile, spawnPos.transform.position, transform.rotation * Quaternion.Euler(0f, -offset, 0f));
        currentProjectile.GetComponent<Projectile>().speed = projectileSpeed;
        currentProjectile.GetComponent<Projectile>().damage = damage;
    }
}
