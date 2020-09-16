using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource shootSound;
        [HideInInspector] public float shootSoundVolume, shootSoundPitch;
    }
    public int damage, slot;
    public float fireRate, radius;
    public new SphereCollider collider;
    [HideInInspector] public GameObject target;
    [HideInInspector] public float longestDist;
    [HideInInspector]public float standardFireRate;
    [HideInInspector] public float lastShotTime = float.MinValue;
    public Sounds sounds;
    void Start()
    {
        longestDist = 0;
        collider.radius = radius;
        standardFireRate = fireRate;

        sounds.shootSoundVolume = sounds.shootSound.volume;
        sounds.shootSoundPitch = sounds.shootSound.pitch;
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
            ShootSound();
        }
        WipeTarget();
    }
    public virtual void Fire()
    {
        target.GetComponent<Enemy>().GetDamage(damage, true);
    }
    void ShootSound()
    {
        sounds.shootSound.volume = Random.Range(sounds.shootSoundVolume - .05f, sounds.shootSoundVolume + .05f);
                sounds.shootSound.pitch = Random.Range(sounds.shootSoundPitch - .1f, sounds.shootSoundPitch + .1f);
                sounds.shootSound.Play();
    }
    public virtual void WipeTarget()
    {
        target = null;
        longestDist = 0;
    }
    private void OnTriggerExit(Collider other)
    {
        WipeTarget();
    }
}
