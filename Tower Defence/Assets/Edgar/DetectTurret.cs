﻿using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DetectTurret : MonoBehaviour
{
    public GameObject turret;
    public Inventory inventoryScript;
    public SettingsManeger settingManager;
    public MoneyManager moneyManager;
    public int upgradePrice;
    public Slider xpSlider;
    public GameObject infoPanel;
    public TextMeshProUGUI infoText, costText, lvText, infoTypeTurret;
    private void Update()
    {
        for (int i = 0; i < turret.GetComponent<TurretRepair>().turretScript.levelStats.stats.Length; i++)
        {
            if (turret.GetComponent<TurretRepair>().turretScript.damage == turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].damage)
            {
                xpSlider.value = turret.GetComponent<TurretRepair>().turretScript.xp / turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[i].nextLvlXp;
            }
        }
        lvText.text = "Lv: " + (turret.GetComponent<TurretRepair>().turretScript.turretLevel + 1);
    }
    public void OnHoverButton(GameObject buttonTurret)
    {
        infoPanel.SetActive(true);
        int levelNow = turret.GetComponent<TurretRepair>().turretScript.turretLevel;
        if (turret.GetComponent<TurretRepair>().turretScript.turretType == buttonTurret.GetComponent<TurretRepair>().turretScript.turretType)
        {
            if(turret.GetComponent<TurretRepair>().turretScript.turretLevel < buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats.Length - 1)
            {
                infoText.text =
                    "Level up turret" +
                    "<br><br>Dmg: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].damage.ToString() +
                    " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].damage.ToString() +
                    "<br>Fire Rate: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].fireRate.ToString() +
                    " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].fireRate.ToString() +
                    "<br>Radius: " + turret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].radius.ToString() +
                    " -> " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow + 1].radius.ToString();

                costText.text = "Cost: " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].cost.ToString();
            }
            else
            {
                infoText.text =
                    "Level up turret" +
                    "<br><br>Dmg: " + "Maxed" +
                    "<br>Fire Rate: " + "Maxed" +
                    "<br>Radius: " + "Maxed";

                costText.text = "";
            }
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

            infoTypeTurret.text = buttonTurret.GetComponentInChildren<Turret>().turretInfo;

            costText.text = "Cost: " + buttonTurret.GetComponent<TurretRepair>().turretScript.levelStats.stats[levelNow].cost.ToString();
        }
    }
    public void OnHoverExitButton()
    {
        infoPanel.SetActive(false);
    }

    public void Upgrade(GameObject newTurret)
    {
        upgradePrice = turret.GetComponentInChildren<Turret>().cost;
        if (turret != null && turret.GetComponentInChildren<Turret>().levelUpReady == true && turret.GetComponentInChildren<Turret>().turretLevel < turret.GetComponentInChildren<Turret>().levelStats.stats.Length - 1)
        {
            if (turret.GetComponentInChildren<Turret>().turretLevel < turret.GetComponentInChildren<Turret>().levelStats.stats.Length - 1 || newTurret.GetComponent<Turret>().turretType != turret.GetComponent<Turret>().turretType)
            {
                if (moneyManager.moneyNumber >= upgradePrice)
                {
                    turret.GetComponentInChildren<Turret>().LevelUp(newTurret);
                    settingManager.Back();
                    moneyManager.GetMoney(-upgradePrice);
                    xpSlider.value = 0;
                }
            }
        }
        inventoryScript.RefreshTurretLevel();
    }
}
