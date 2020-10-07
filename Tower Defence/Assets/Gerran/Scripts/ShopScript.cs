using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    public int numHP,numFirerate,numFreeze,numNuke,numSpike,prizeHP, prizeFirerate, prizeFreeze, prizeNuke, prizeSpike;
    public GameObject money;
    public Text iGFirerateNumText, iGFreezeNumText, iGNukeNumText, iGSpikeNumText;

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
        iGSpikeNumText.text = numSpike.ToString();
    }

    public void BuyHP()
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeHP)
        {
            numHP += 1;
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
        if (money.GetComponent<MoneyManager>().moneyNumber >= prizeSpike)
        {
            numSpike += 1;
            money.GetComponent<MoneyManager>().GetMoney(-prizeSpike);
        }
    }
}
