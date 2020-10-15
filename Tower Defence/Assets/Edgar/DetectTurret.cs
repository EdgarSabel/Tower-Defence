using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DetectTurret : MonoBehaviour
{
    public GameObject turret;
    public SettingsManeger settingManager;
    public MoneyManager moneyManager;
    public int upgradePrice;
    public Slider xpSlider;
    public GameObject infoPanel;
    public TextMeshProUGUI infoText, costText, lvText;
    private void Update()
    {
        for (int i = 0; i < turret.GetComponent<TurretRepair>().turretScript.levelStats.stats.Length; i++)
        {
            if (turret.GetComponent<TurretRepair>().turretScript.damage == turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].damage)
            {
                xpSlider.value = turret.GetComponent<TurretRepair>().turretScript.xp / turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].nextLvlXp;

                //infoText.text = turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].damage.ToString() + " -> " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i + 1].damage.ToString();
            }
        }
        lvText.text = "Lv: " + turret.GetComponent<TurretRepair>().turretScript.turretLevel;
    }

                //infoText.text = turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].damage.ToString() + " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i + 1].damage.ToString();
    public void OnHoverButton(GameObject buttonTurret)
    {
        infoPanel.SetActive(true);
        int levelNow = turret.GetComponent<TurretRepair>().turretScript.turretLevel;
        if(turret.GetComponent<TurretRepair>().turretScript.turretType == buttonTurret.GetComponent<TurretRepair>().turretScript.turretType)
        {
            infoText.text =
                "Level up turret" +
                "<br><br>Dmg: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].damage.ToString() +
                " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].damage.ToString() + 
                "<br>Fire Rate: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].fireRate.ToString() +
                " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].fireRate.ToString() +
                "<br>Radius: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].radius.ToString() +
                " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].radius.ToString();

            //costText.text = buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].cost.ToString();
        }
        else
        {
            infoText.text =
                turret.GetComponent<TurretRepair>().turretScript.turretType + "<br>-><br>" + buttonTurret.GetComponent<TurretRepair>().turretScript.turretType +
                "<br><br>Dmg: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].damage.ToString() +
                " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].damage.ToString() +
                "<br>Fire Rate: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].fireRate.ToString() +
                " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].fireRate.ToString() +
                "<br>Radius: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].radius.ToString() +
                " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].radius.ToString();

            //costText.text = "Cost: " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].cost.ToString();
        }
    }
    public void OnHoverExitButton()
    {
        infoPanel.SetActive(false);
    }

    public void Upgrade(GameObject newTurret)
    {
        upgradePrice = turret.GetComponentInChildren<Turret>().cost;
        if (turret != null && turret.GetComponentInChildren<Turret>().levelUpReady == true)
        {
            if (moneyManager.moneyNumber >= upgradePrice)
            {
            turret.GetComponentInChildren<Turret>().LevelUp(newTurret);
            settingManager.Back();
                moneyManager.GetMoney(-upgradePrice);
                xpSlider.value = 0;
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
