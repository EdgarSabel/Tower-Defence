using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PickupTurret : MonoBehaviour
{
    public float range;
    public Inventory inventory;
    private Turret turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inventory.isHovering != true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, -5, QueryTriggerInteraction.Ignore))
            {
                if (hit.transform.gameObject.tag == "Turret")
                {
                    turret = hit.transform.gameObject.GetComponent<Turret>();
                    inventory.turrets[turret.slot] = turret.gameObject;
                    turret.gameObject.SetActive(false);
                }
            }
        }
    }
}
