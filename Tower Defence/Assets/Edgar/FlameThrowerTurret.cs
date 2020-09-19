using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class FlameThrowerTurret : Turret
{
    public bool isFiring;
    public VisualEffect vfx;
    public float burnDuration;
    bool isStarted;
    void Start()
    {

    }

    public override void Update()
    {
        base.Update();
        PlaySounds();
    }

    public override void Fire()
    {
        if (isFiring == false)
        {
            vfx.Play();
            isFiring = true;
        }
    }
    
    void PlaySounds()
    {
        if(isFiring == true && isStarted == false)
        {
            isStarted = true;
            sounds.shootSound.volume = Random.Range(sounds.shootSoundVolume - .05f, sounds.shootSoundVolume + .05f);
            sounds.shootSound.pitch = Random.Range(sounds.shootSoundPitch - .1f, sounds.shootSoundPitch + .1f);
            sounds.shootSound.Play();
        }
        else if(isFiring == false && sounds.shootSound.isPlaying == true)
        {
            isStarted = false;
            sounds.shootSound.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        vfx.Stop();
        isFiring = false;
    }
}