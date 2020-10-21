using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurret : Turret
{
    public ParticleSystem cannonSmoke;
    public GameObject projectile, currentProjectile, spawnPos;
    public float projectileSpeed;

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
        cannonSmoke.Play();
        currentProjectile = Instantiate(projectile, spawnPos.transform.position, transform.rotation);
        currentProjectile.GetComponent<CBall>().speed = projectileSpeed;
        currentProjectile.GetComponent<CBall>().damage = damage;
        currentProjectile.GetComponent<CBall>().target = target;

    }
}
