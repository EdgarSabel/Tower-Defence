using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class FlameThrowerTurret : Turret
{
    public bool isFiring;
    public VisualEffect vfx;
    public float burnDuration;
    void Start()
    {
        vfx.Stop();
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