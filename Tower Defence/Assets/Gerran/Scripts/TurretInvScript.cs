using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInvScript : MonoBehaviour
{

    public Image[] slots;
    public bool[] isfull;
    public GameObject pickupTurretScript,turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (pickupTurretScript.GetComponent<PickupTurret>().inventory.isHovering != true)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickupTurretScript.GetComponent<PickupTurret>().range, -5, QueryTriggerInteraction.Ignore))
                {
                    if (hit.transform.gameObject.tag == "Turret")
                    {

                    }
                }
            }
        }

    }
}
