using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{

    public int numFirerate,numFreeze,numNuke,prizeHP, prizeFirerate, prizeFreeze, prizeNuke, prizeTurretRepairSpeed;
    public GameObject money;
    public TextMeshProUGUI iGFirerateNumText, iGFreezeNumText, iGNukeNumText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iGFirerateNumText.text = numFirerate.ToString();
        iGFreezeNumText.text = numFreeze.ToString();
        iGNukeNumText.text = numNuke.ToString();
        //iGSpikeNumText.text = numSpike.ToString();
    }

    public void BuyHP()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeHP)
        {
            //give health max health= 120
            money.GetComponent<MoneyManager>().GetMoney(-prizeHP);
        }
    }

    public void BuyFirerate()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeFirerate)
        {
            numFirerate += 1;
            money.GetComponent<MoneyManager>().GetMoney(-prizeFirerate);
        }
    }

    public void BuyFreeze()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeFreeze)
        {
            numFreeze += 1;
            money.GetComponent<MoneyManager>().GetMoney(-prizeFreeze);
        }
    }

    public void BuyNuke()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeNuke)
        {
            numNuke += 1;
            money.GetComponent<MoneyManager>().GetMoney(-prizeNuke);
        }
    }

    public void BuySpike()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeTurretRepairSpeed)
        {
            //decrease turret repair speed
            money.GetComponent<MoneyManager>().GetMoney(-prizeTurretRepairSpeed);
        }
    }
}
