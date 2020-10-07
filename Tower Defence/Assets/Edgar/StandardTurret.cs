using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class StandardTurret : Turret
{
    public ParticleSystem muzzleFlash;

    public override void Fire()
    {
        base.Fire();
        muzzleFlash.Play();
    }
}
