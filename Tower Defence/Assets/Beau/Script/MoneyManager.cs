using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int moneyNumber;
    public TextMeshProUGUI moneyText, shopText;

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
    }
}
