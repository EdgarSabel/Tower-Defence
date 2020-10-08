using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerFlame : MonoBehaviour
{
    public FlameThrowerTurret turret;
    private Enemy target;
    [HideInInspector] public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        turret = GetComponentInParent<FlameThrowerTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (inventory.isHovering == false)
        {

            if (other.gameObject.tag == "Enemy")
            {
                target = other.gameObject.GetComponent<Enemy>();
                if (target.isBurning == false)
                {
                    target.burnDmg = turret.damage;
                    target.burnRate = turret.fireRate;
                    target.isBurning = true;
                    target.duration = turret.burnDuration;
                }
                else
                {
                    target.burnTimer = 0;
                }

                if (turret.target = null)
                {
                    turret.vfx.Stop();
                    turret.isFiring = false;
                }
            }
        }
    }
}
