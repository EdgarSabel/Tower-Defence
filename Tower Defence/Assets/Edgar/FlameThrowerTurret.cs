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

    }

    public override void Fire()
    {
        if (isFiring == false)
        {
            vfx.Play();
            isFiring = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        vfx.Stop();
        isFiring = false;
    }
}