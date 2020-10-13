﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterectScript : MonoBehaviour
{

    public GameObject upgradePanel, shopPanel, hudPanel, cam, player, turret;
    public RaycastHit hit;
    public GameObject menuPanel, shopIntText, turretPUText, turretUGText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.tag == ("Turret"))
            {
                if (player.GetComponent<Inventory>().isHovering == false)
                {
                    turretPUText.SetActive(true);
                    turretUGText.SetActive(true);
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    upgradePanel.GetComponent<DetectTurret>().turret = hit.transform.gameObject;
                    upgradePanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }

            else if (hit.transform.tag == ("Shop"))
            {
                shopIntText.SetActive(true);
                if (Input.GetButtonDown("Fire2"))
                {
                    shopPanel.SetActive(true);
                    hudPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    cam.GetComponent<CamLook>().canMove = false;
                    //player.GetComponent<CamLook>().canMove = false;
                }
            }
            else
            {
                shopIntText.SetActive(false);
                turretPUText.SetActive(false);
                turretUGText.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            cam.GetComponent<CamLook>().enabled = !enabled;
            player.GetComponent<PlayerMovement>().enabled = !enabled;
            menuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
