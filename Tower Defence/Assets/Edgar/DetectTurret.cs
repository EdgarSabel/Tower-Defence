using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DetectTurret : MonoBehaviour
{
    public GameObject turret;
    public SettingsManeger settingManager;
    public MoneyManager moneyManager;
    public int upgradePrice;
    public Slider xpSlider;
    private void Update()
    {
        for (int i = 0; i < turret.GetComponent<TurretRepair>().turretScript.levelStats.stats.Length; i++)
        {
            if (turret.GetComponent<TurretRepair>().turretScript.damage == turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].damage)
            {
                xpSlider.value = turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].xp / turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].nextLvlXp;
            }
        }
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
