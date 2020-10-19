using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{

    public int numFirerate,numFreeze,numNuke,prizeHP, prizeFirerate, prizeFreeze, prizeNuke, prizeTurretRepairSpeed, healthPlus;
    public GameObject money, turret, shopPanel, hudPanel, player, cam;
    public int maxRange;
    public TextMeshProUGUI iGFirerateNumText, iGFreezeNumText, iGNukeNumText;
    public float decreaseNum, min;
    public TextMeshProUGUI costHealth, costFirerate, costFreeze, costNuke, costRepair;
    public AudioSource buySound, notEnoughMoneySound;
    // Start is called before the first frame update
    void Start()
    {
        costHealth.text = "Cost: " + prizeHP.ToString();
        costFirerate.text = "Cost: " + prizeFirerate.ToString();
        costFreeze.text = "Cost: " + prizeFreeze.ToString();
        costNuke.text = "Cost: " + prizeNuke.ToString();
        costRepair.text = "Cost: " + prizeTurretRepairSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        iGFirerateNumText.text = numFirerate.ToString();
        iGFreezeNumText.text = numFreeze.ToString();
        iGNukeNumText.text = numNuke.ToString();
    }

    public void BuyHP()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeHP)
        {
            if (money.GetComponent<HealthManager>().health < 120)
            {
                //give health max health= 120
                buySound.Play();
                money.GetComponent<HealthManager>().health += healthPlus;
                if(money.GetComponent<HealthManager>().health >= 120)
                {
                    money.GetComponent<HealthManager>().health = 120;
                }
                money.GetComponent<HealthManager>().UpdateHealthNumber();
                money.GetComponent<MoneyManager>().GetMoney(-prizeHP);
            }
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyFirerate()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeFirerate)
        {
            numFirerate += 1;
            buySound.Play();
            money.GetComponent<MoneyManager>().GetMoney(-prizeFirerate);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyFreeze()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeFreeze)
        {
            numFreeze += 1;
            buySound.Play();
            money.GetComponent<MoneyManager>().GetMoney(-prizeFreeze);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyNuke()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeNuke)
        {
            numNuke += 1;
            buySound.Play();
            money.GetComponent<MoneyManager>().GetMoney(-prizeNuke);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuySpike()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeTurretRepairSpeed)
        {
            //decrease turret repair speed
            buySound.Play();
            min = 5 / decreaseNum;
            turret.GetComponent<TurretRepair>().decreaseNumber -= min;
            money.GetComponent<MoneyManager>().GetMoney(-prizeTurretRepairSpeed);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }
}
