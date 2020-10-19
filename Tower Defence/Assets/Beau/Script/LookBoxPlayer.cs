using UnityEngine;

public class LookBoxPlayer : MonoBehaviour
{
    public GameObject shopPanel, turretPanel, hudPanel, cam;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Shop" || other.gameObject.tag == "Turret")
        {
            if(shopPanel.activeSelf == true)
            {
                shopPanel.SetActive(false);
                hudPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cam.GetComponent<CamLook>().canMove = true;
            }
            if(turretPanel.activeSelf == true)
            {
                turretPanel.SetActive(false);
                hudPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cam.GetComponent<CamLook>().canMove = true;
            }
        }
    }
}
