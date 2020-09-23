using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [System.Serializable]
    public class LevelOptions
    {
        public Stats[] stats;
    }
    [System.Serializable]
    public class Stats
    {
        public int damage;
        public float fireRate, radius, xp, nextLvlXp;
    }
    [System.Serializable]
    public class Sounds
    {
        public AudioSource shootSound;
        [HideInInspector] public float shootSoundVolume, shootSoundPitch;
    }
    public string turretType;
    public bool levelUpReady;
    public int damage, slot;
    public float fireRate, radius, levelSpeed, nextLvlXp;
    public new SphereCollider collider;
    [HideInInspector] public GameObject target;
    [HideInInspector]public float standardFireRate, longestDist, xp, lastShotTime = float.MinValue;
    [HideInInspector] public int turretLevel;
    private GameObject turretSpawned;
    public Sounds sounds;
    public LevelOptions levelStats;
    public Animator animTop,animBot;
    void Start()
    {
        StatRefresh();
        longestDist = 0;
        collider.radius = radius;
        standardFireRate = fireRate;

        sounds.shootSoundVolume = sounds.shootSound.volume;
        sounds.shootSoundPitch = sounds.shootSound.pitch;
    }

    public virtual void Update()
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
            EarnXP();
        }
        WipeTarget();
    }
    public virtual void Fire()
    {
        target.GetComponent<Enemy>().GetDamage(damage, true);
    }
    public void ShootSound()
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

    public void EarnXP()
    {
        xp += levelSpeed;
        //update xp bar here :)
        if (xp >= nextLvlXp)
        {
            levelUpReady = true;
            //show level up available
        }
    }

    public void StatRefresh()
    {
        damage = levelStats.stats[turretLevel].damage;
        fireRate = levelStats.stats[turretLevel].fireRate;
        radius = levelStats.stats[turretLevel].radius;
        nextLvlXp = levelStats.stats[turretLevel].nextLvlXp;
    }
    //function for shop purchase :O
    public void LevelUp(GameObject newTurret)
    {
        if (newTurret.GetComponent<Turret>().turretType == turretType)
        {
            turretLevel += 1;
            levelUpReady = false;
            StatRefresh();
        }
        else
        {
        Destroy(this.gameObject);
        turretSpawned = Instantiate(newTurret, transform.position, transform.rotation);
        turretSpawned.GetComponent<Turret>().slot = slot;
        turretSpawned.GetComponent<Turret>().turretLevel = turretLevel;
        turretSpawned.GetComponent<Turret>().StatRefresh();
        }
    }
}
