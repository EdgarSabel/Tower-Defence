using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTurret : MonoBehaviour
{
    public GameObject turret;
    public SettingsManeger settingManager;
    public MoneyManager moneyManager;
    public int upgradePrice;
    private void Update()
    {

    }

    public void Upgrade(GameObject newTurret)
    {
        if (turret != null && turret.GetComponentInChildren<Turret>().levelUpReady == true)
        {
            if (moneyManager.moneyNumber >= upgradePrice)
            {
            turret.GetComponentInChildren<Turret>().LevelUp(newTurret);
            settingManager.Back();
                moneyManager.GetMoney(-upgradePrice);
            }
            else
            {
                //not enough money pop up
            }
        }
        else
        {
            //not enough XP pop up
        }
    }
}
