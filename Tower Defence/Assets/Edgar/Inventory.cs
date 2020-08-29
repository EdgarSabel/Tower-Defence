using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public GameObject[] turrets;
    public float range;
    public GameObject cam;
    public float xp1, xp2, xp3;
    private Vector3 offset = new Vector3(0, (float)0.5, 0);

    private void Start()
    {
        cam = GameObject.Find("Camera");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Slot2") && turrets[0] != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.tag == "Ground")
                {
                    turrets[0].gameObject.SetActive(true);
                    turrets[0].gameObject.transform.position = hit.point + offset;
                    turrets[0] = null;
                }
            }

        }
        if (Input.GetButtonDown("Slot3") && turrets[1] != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.tag == "Ground")
                {
                    turrets[1].gameObject.SetActive(true);
                    turrets[1].gameObject.transform.position = hit.point + offset;
                    turrets[1] = null;
                }
            }
        }
        if (Input.GetButtonDown("Slot4") && turrets[2] != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.tag == "Ground")
                {
                    turrets[2].gameObject.SetActive(true);
                    turrets[2].gameObject.transform.position = hit.point + offset;
                    turrets[2] = null;
                }
            }
        }
    }
}
