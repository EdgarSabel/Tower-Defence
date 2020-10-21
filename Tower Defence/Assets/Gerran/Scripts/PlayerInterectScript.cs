﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterectScript : MonoBehaviour
{

    public GameObject upgradePanel, shopPanel, hudPanel, cam, player, turret;
    public RaycastHit hit;
    public GameObject menuPanel, shopIntText, turretPUText, turretUGText;
    public int range = 5;

    public GameObject mainCam, shopCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range, -5, QueryTriggerInteraction.Ignore))
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
                    shopPanel.SetActive(false);
                    menuPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            else if (hit.transform.tag == ("Shop"))
            {
                shopIntText.SetActive(true);
                if (Input.GetButtonDown("Fire2"))
                {
                    shopCam.SetActive(true);
                    player.GetComponent<PlayerMovement>().enabled = !enabled;
                    cam.GetComponent<CamLook>().enabled = !enabled;

                    upgradePanel.SetActive(false);
                    menuPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    cam.GetComponent<CamLook>().canMove = false;
                }
            }
            else if (shopIntText.activeSelf == true || turretPUText.activeSelf == true || turretUGText.activeSelf == true)
            {
                shopIntText.SetActive(false);
                turretPUText.SetActive(false);
                turretUGText.SetActive(false);
            }
        }
        else if(shopIntText.activeSelf == true || turretPUText.activeSelf == true || turretUGText.activeSelf == true)
        {
            shopIntText.SetActive(false);
            turretPUText.SetActive(false);
            turretUGText.SetActive(false);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if(menuPanel.activeSelf == false)
            {
                cam.GetComponent<CamLook>().enabled = !enabled;
                player.GetComponent<PlayerMovement>().enabled = !enabled;
                menuPanel.SetActive(true);
                upgradePanel.SetActive(false);
                shopPanel.SetActive(false);
                hudPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (menuPanel.activeSelf == true)
            {
                if(shopPanel.activeSelf == true)
                {
                    shopCam.SetActive(false);
                    player.GetComponent<PlayerMovement>().enabled = enabled;
                    cam.GetComponent<CamLook>().enabled = enabled;
                }
                cam.GetComponent<CamLook>().enabled = enabled;
                player.GetComponent<PlayerMovement>().enabled = enabled;
                menuPanel.SetActive(false);
                hudPanel.SetActive(true);
                cam.GetComponent<CamLook>().canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
        }
    }
}
