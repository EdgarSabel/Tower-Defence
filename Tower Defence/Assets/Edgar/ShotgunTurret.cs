using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTurret : Turret
{
    public GameObject projectile, currentProjectile, spawnPos;
    public float projectileSpeed;
    public float offset;

    public override void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform.GetComponent<Enemy>() != null)
            {
                if (hitCollider.transform.GetComponent<Enemy>().isFlying == false)
                {

                    if (hitCollider.transform.GetComponent<Enemy>().distTravel > longestDist)
                    {
                        longestDist = hitCollider.transform.GetComponent<Enemy>().distTravel;
                        target = hitCollider.transform.gameObject;
                    }
                }
            }
        }
        if (target != null)
        {
            transform.LookAt(target.transform.Find("HitLoc").position);
        }

        if (target != null && Time.time > lastShotTime + (3.0f / fireRate))
        {
            lastShotTime = Time.time;
            ShootSound();
            EarnXP();
            Fire();
        }
        Invoke("WipeTarget", 0.0000001f);
    }
    public override void Fire()
    {
        animTop.SetTrigger("Shoot");
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
