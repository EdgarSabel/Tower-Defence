using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPath : MonoBehaviour
{
    public Inventory inventory;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (inventory.isOnPath != true)
            {
                inventory.isOnPath = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (inventory.isOnPath == true)
            {
                inventory.isOnPath = false;
            }
        }
    }
}
