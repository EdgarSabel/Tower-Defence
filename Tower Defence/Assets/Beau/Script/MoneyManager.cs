using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int moneyNumber;
    public Text moneyText, shopText;

    private void Start()
    {
        UpdateMoneyNumber();
    }
    public void GetMoney(int money)
    {
        moneyNumber += money;
        UpdateMoneyNumber();
    }
    void UpdateMoneyNumber()
    {
        moneyText.text = moneyNumber.ToString();
        shopText.text = moneyNumber.ToString();
    }
}
