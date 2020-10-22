using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterectScript : MonoBehaviour
{
    public GameObject upgradePanel, hudPanel, cam, player, turret, turretColBox;
    public RaycastHit hit;
    public GameObject menuPanel, shopIntText, turretPUText, turretUGText, optionsPanel;
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

                    turretColBox.SetActive(true);
                    turretColBox.GetComponent<LookBoxPlayer>().currentTurret = hit.transform.gameObject;

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
            if (menuPanel.activeSelf == false && shopCam.activeSelf == false && upgradePanel.activeSelf == false && optionsPanel.activeSelf == false)
            {
                //Menu on
                hudPanel.SetActive(false);
                menuPanel.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = !enabled;
                cam.GetComponent<CamLook>().enabled = !enabled;
                cam.GetComponent<CamLook>().canMove = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if(menuPanel.activeSelf == false && shopCam.activeSelf == true && upgradePanel.activeSelf == false && optionsPanel.activeSelf == false)
            {
                //Shop off
                shopCam.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = enabled;
                cam.GetComponent<CamLook>().enabled = enabled;
                cam.GetComponent<CamLook>().canMove = true;

                waitForNextRoundObj.GetComponent<TextMeshProUGUI>().color = normalColor;
                skipObj.GetComponent<TextMeshProUGUI>().color = normalColor;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (menuPanel.activeSelf == true && shopCam.activeSelf == false && upgradePanel.activeSelf == false && optionsPanel.activeSelf == false)
            {
                //Menu off
                hudPanel.SetActive(true);
                menuPanel.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = enabled;
                cam.GetComponent<CamLook>().enabled = enabled;
                cam.GetComponent<CamLook>().canMove = true;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if(menuPanel.activeSelf == false && shopCam.activeSelf == false && upgradePanel.activeSelf == true && optionsPanel.activeSelf == false)
            {
                //Upgrade off
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                upgradePanel.SetActive(false);
                upgradePanel.GetComponent<DetectTurret>().turret = null;
                turretColBox.GetComponent<LookBoxPlayer>().currentTurret = null;
                turretColBox.GetComponent<LookBoxPlayer>().gameObject.SetActive(false);
                StartCoroutine(CursorLock());
            }
            else if (menuPanel.activeSelf == false && shopCam.activeSelf == false && upgradePanel.activeSelf == false && optionsPanel.activeSelf == true)
            {
                //Options back
                menuPanel.SetActive(true);
                optionsPanel.SetActive(false);
            }
        }
    }
    IEnumerator CursorLock()
    {
        yield return new WaitForEndOfFrame();
        cam.GetComponent<CamLook>().enabled = enabled;
        cam.GetComponent<CamLook>().canMove = true;
    }
}
