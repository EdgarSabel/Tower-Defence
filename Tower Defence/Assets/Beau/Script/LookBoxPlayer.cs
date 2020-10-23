using UnityEngine;

public class LookBoxPlayer : MonoBehaviour
{
    public GameObject turretPanel, hudPanel, cam, interactObj;
    [HideInInspector]public GameObject currentTurret;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == currentTurret)
        { 
            turretPanel.SetActive(false);
            hudPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.GetComponent<CamLook>().canMove = true;
            currentTurret = null;
            interactObj.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
