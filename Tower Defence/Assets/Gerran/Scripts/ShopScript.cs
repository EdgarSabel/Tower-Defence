using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{

    public int numFirerate,numFreeze,numNuke, healthPlus;
    public GameObject money, turret;
    public float decreaseNum, min;
    public TextMeshProUGUI itemInfo, cost;
    public AudioSource buySound, notEnoughMoneySound;
    public RaycastHit hit;
    public GameObject shopCam;
    void Update()
    {
        Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
        if(shopCam.activeSelf == true)
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, -5, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.tag == "ShopItem")
                {
                    int itemId = hit.collider.gameObject.GetComponent<ItemInShop>().itemId;
                    if (itemId == 0)
                    {
                        itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                        cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                    }
                    else if (itemId == 1)
                    {
                        itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                        cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                    }
                    else if (itemId == 2)
                    {
                        itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                        cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                    }
                    else if (itemId == 3)
                    {
                        itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                        cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                    }
                    else if (itemId == 4)
                    {
                        itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                        cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                    }
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    if(hit.collider.gameObject.tag == "ShopItem")
                    {
                        int itemId = hit.collider.gameObject.GetComponent<ItemInShop>().itemId;
                        if(itemId == 0)
                        {
                            BuyHP(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if(itemId == 1)
                        {
                            BuyFirerate(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 2)
                        {
                            BuyFreeze(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 3)
                        {
                            BuyNuke(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 4)
                        {
                            BuyTurretRepairSpeed(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                    }
                }
            }
    }

    public void BuyHP(int prize)
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
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
                money.GetComponent<MoneyManager>().GetMoney(-prize);
            }
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyFirerate(int prize)
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
        {
            numFirerate += 1;
            buySound.Play();
            money.GetComponent<MoneyManager>().GetMoney(-prize);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyFreeze(int prize)
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
        {
            numFreeze += 1;
            buySound.Play();
            money.GetComponent<MoneyManager>().GetMoney(-prize);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyNuke(int prize)
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
        {
            numNuke += 1;
            buySound.Play();
            money.GetComponent<MoneyManager>().GetMoney(-prize);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyTurretRepairSpeed(int prize)
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
        {
            //decrease turret repair speed
            buySound.Play();
            min = 5 / decreaseNum;
            turret.GetComponent<TurretRepair>().decreaseNumber -= min;
            money.GetComponent<MoneyManager>().GetMoney(-prize);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }
}
