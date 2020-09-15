using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterectScript : MonoBehaviour
{

    public GameObject upgradePanel;
    public RaycastHit hit;

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
                if (Input.GetButtonDown("Interact"))
                {
                    upgradePanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}
