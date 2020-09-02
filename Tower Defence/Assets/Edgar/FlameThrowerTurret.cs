using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class FlameThrowerTurret : Turret
{
    public bool isFiring;
    public VisualEffect vfx;
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

    public override void WipeTarget()
    {
        base.WipeTarget();
        isFiring = false;
        vfx.Stop();
    }
}