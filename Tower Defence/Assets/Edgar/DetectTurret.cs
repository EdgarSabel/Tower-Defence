using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTurret : MonoBehaviour
{
    public GameObject turret;
    public SettingsManeger settingManager;
    private void Update()
    {

    }

    public void Upgrade(GameObject newTurret)
    {
        if (turret != null && turret.GetComponentInChildren<Turret>().levelUpReady == true)
        {
            turret.GetComponentInChildren<Turret>().LevelUp(newTurret);
            settingManager.Back();
        }
    }
}
