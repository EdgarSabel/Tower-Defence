using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class PlayerWeapon : MonoBehaviour
{
    public int playerDmg, repairNumber;
    public float playerWeaponRange, playerWeaponDelay;
    public GameObject cam;

    public GameObject hitMapParticles;

    bool canHit = true;
    RaycastHit hit;

    private void Update()
    {
        Ray ray = new Ray(cam.transform.localPosition, Vector3.forward);

        Debug.DrawRay(cam.transform.position, cam.transform.forward * playerWeaponRange, Color.green);

        if (Input.GetMouseButtonDown(0) && canHit == true)
        {
            canHit = false;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, playerWeaponRange))
            {
                Instantiate(hitMapParticles, hit.point, Quaternion.RotateTowards(Quaternion.identity, this.gameObject.transform.rotation, 1));
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().GetDamage(playerDmg, true);
                }
                else if(hit.transform.tag == "Turret")
                {
                    hit.transform.GetComponent<TurretRepair>().healthTurret += repairNumber;
                }
            }
            StartCoroutine(PlayerWeaponDelay());
        }
    }
    IEnumerator PlayerWeaponDelay()
    {
        yield return new WaitForSeconds(playerWeaponDelay);
        canHit = true;
    }
}
