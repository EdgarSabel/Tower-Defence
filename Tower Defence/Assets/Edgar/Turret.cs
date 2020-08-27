using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int damage;
    public float fireRate;
    public float radius;
    private float longestDist;
    public GameObject target;
    public new SphereCollider collider;
    private float lastShotTime = float.MinValue;

    [HideInInspector]public float standardFireRate;
    // Start is called before the first frame update
    void Start()
    {
        collider.radius = radius;
        standardFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
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
        }
    }
    public void Fire()
    {
        target.GetComponent<Enemy>().GetDamage(damage, true);
        target = null;
        longestDist = 0;
    }
    private void OnTriggerExit(Collider other)
    {
        target = null;
        longestDist = 0;
    }
}
