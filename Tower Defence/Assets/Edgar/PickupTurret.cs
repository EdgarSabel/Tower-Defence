using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PickupTurret : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource pickUpTurret;
        [HideInInspector] public float pickUpTurretVolume, pickUpTurretPitch;
    }

    public float range;
    public Inventory inventory;
    private GameObject turret;
    public Animator anim;
    public Sounds sounds;
    public bool[] isfull;
    public Image[] slots;


    private void Start()
    {
        sounds.pickUpTurretVolume = sounds.pickUpTurret.volume;
        sounds.pickUpTurretPitch = sounds.pickUpTurret.pitch;
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (inventory.isHovering != true)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, range, -5, QueryTriggerInteraction.Ignore))
                {
                    if (hit.transform.gameObject.tag == "Turret")
                    {
                        anim.SetTrigger("PickUp");
                        turret = hit.transform.gameObject;
                        inventory.turrets[turret.GetComponentInChildren<Turret>().slot] = turret;
                        turret.gameObject.SetActive(false);

                        sounds.pickUpTurret.volume = Random.Range(sounds.pickUpTurretVolume - .05f, sounds.pickUpTurretVolume + .05f);
                        sounds.pickUpTurret.pitch = Random.Range(sounds.pickUpTurretPitch - .1f, sounds.pickUpTurretPitch + .1f);
                        sounds.pickUpTurret.Play();
                        slots[turret.GetComponentInChildren<Turret>().slot].sprite = turret.GetComponentInChildren<Turret>().invSprite;
                    }
                }
            }
        }
    }
}
