using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterectScript : MonoBehaviour
{

    public GameObject upgradePanel, shopPanel, hudPanel, cam, player, turret;
    public RaycastHit hit;
    public GameObject menuPanel;

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
                if (Input.GetButtonDown("Fire2"))
                {
                    upgradePanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }

            else if (hit.transform.tag == ("Shop"))
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    shopPanel.SetActive(true);
                    hudPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    cam.GetComponent<CamLook>().canMove = false;
                    player.GetComponent<CamLook>().canMove = false;
                }
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            menuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
