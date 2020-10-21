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

    public GameObject player, cam, upgradePanel, menuPanel, waitForNextRoundObj, skipObj;
    public Color normalColor;
    void Update()
    {
        Ray ray = shopCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (shopCam.activeSelf == true)
        {
            if (Physics.Raycast(ray, out hit, 1000, -5, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.tag == "ShopItem")
                {
                    int itemId = hit.collider.gameObject.GetComponent<ItemInShop>().itemId;
                    if (itemId == 1)
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
                    else if (itemId == 5)
                    {
                        itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                        cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                    }
                }
                else
                {
                    itemInfo.text = "";
                    cost.text = "";
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    if (hit.collider.gameObject.tag == "ShopItem")
                    {
                        int itemId = hit.collider.gameObject.GetComponent<ItemInShop>().itemId;
                        if (itemId == 1)
                        {
                            print("try to buy health");
                            BuyHP(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 2)
                        {
                            BuyFirerate(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 3)
                        {
                            BuyFreeze(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 4)
                        {
                            BuyNuke(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 5)
                        {
                            BuyTurretRepairSpeed(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                        }
                        else if (itemId == 6)
                        {
                            shopCam.SetActive(false);
                            player.GetComponent<PlayerMovement>().enabled = enabled;
                            cam.GetComponent<CamLook>().enabled = enabled;
                            cam.GetComponent<CamLook>().canMove = true;

                            waitForNextRoundObj.GetComponent<TextMeshProUGUI>().color = normalColor;
                            skipObj.GetComponent<TextMeshProUGUI>().color = normalColor;

                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = true;
                        }
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
