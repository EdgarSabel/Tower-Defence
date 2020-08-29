using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public GameObject[] turrets;
    public float xp1, xp2, xp3;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("Slot2") && turrets[0] != null)
        {
            turrets[0].gameObject.SetActive(true);
            turrets[0].gameObject.transform.position = transform.position;
            turrets[0] = null;
        }
        if (Input.GetButtonDown("Slot3") && turrets[1] != null)
        {
            turrets[1].gameObject.SetActive(true);
            turrets[1].gameObject.transform.position = transform.position;
            turrets[1] = null;
        }
        if (Input.GetButtonDown("Slot4") && turrets[2] != null)
        {
            turrets[2].gameObject.SetActive(true);
            turrets[2].gameObject.transform.position = transform.position;
            turrets[2] = null;
        }
    }
}
