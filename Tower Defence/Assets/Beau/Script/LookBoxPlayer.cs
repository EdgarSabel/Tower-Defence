﻿using UnityEngine;

public class LookBoxPlayer : MonoBehaviour
{
    public GameObject turretPanel, hudPanel, cam;
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
            this.gameObject.SetActive(false);
        }
    }
}
