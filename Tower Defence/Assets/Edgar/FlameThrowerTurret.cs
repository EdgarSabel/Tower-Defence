using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class FlameThrowerTurret : Turret
{
    public MeshRenderer flameMR;
    public bool isFiring;
    public VisualEffect vfx;
    public float[] burnDuration;

    public override void Start()
    {
        base.Start();
        vfx.Stop();
    }
    public override void StatRefresh()
    {
        if (turretLevel == 4)
        {
            flameMR.material = maxLvlTop;
            botMR.material = maxLvlBot;
        }

        xp = 0;
        cost = levelStats.stats[turretLevel].cost;
        damage = levelStats.stats[turretLevel].damage;
        fireRate = levelStats.stats[turretLevel].fireRate;
        radius = levelStats.stats[turretLevel].radius;
        nextLvlXp = levelStats.stats[turretLevel].nextLvlXp;
    }

    public override void Update()
    {
        base.Update();
        if(target == null)
        {
            vfx.Stop();
            sounds.shootSound.Stop();
            isFiring = false;
        }
    }
    public override void Fire()
    {
        if (isFiring == false)
        {
            sounds.shootSound.volume = Random.Range(sounds.shootSoundVolume - .02f, sounds.shootSoundVolume + .02f);
            sounds.shootSound.pitch = Random.Range(sounds.shootSoundPitch - .1f, sounds.shootSoundPitch + .1f);
            sounds.shootSound.Play();
            vfx.Play();
            isFiring = true;
        }
    }
}