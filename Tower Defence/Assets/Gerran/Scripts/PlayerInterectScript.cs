using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterectScript : MonoBehaviour
{

    public GameObject upgradePanel, hudPanel, cam, player, turret;
    public RaycastHit hit;
    public GameObject menuPanel, shopIntText, turretPUText, turretUGText;
    public int range = 5;

    public GameObject mainCam, shopCam, waitForNextRoundObj, skipObj;
    public Color color, normalColor;
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

                    waitForNextRoundObj.GetComponent<TextMeshProUGUI>().color = color;
                    skipObj.GetComponent<TextMeshProUGUI>().color = color;

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
            if (menuPanel.activeSelf == false && shopCam.activeSelf == false)
            {
                hudPanel.SetActive(false);
                menuPanel.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = !enabled;
                cam.GetComponent<CamLook>().enabled = !enabled;
                cam.GetComponent<CamLook>().canMove = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if(shopCam.activeSelf == true)
            {
                print("exit shop");
                shopCam.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = enabled;
                cam.GetComponent<CamLook>().enabled = enabled;
                cam.GetComponent<CamLook>().canMove = true;

                waitForNextRoundObj.GetComponent<TextMeshProUGUI>().color = normalColor;
                skipObj.GetComponent<TextMeshProUGUI>().color = normalColor;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (menuPanel.activeSelf == true)
            {
                hudPanel.SetActive(true);
                menuPanel.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = enabled;
                cam.GetComponent<CamLook>().enabled = enabled;
                cam.GetComponent<CamLook>().canMove = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
