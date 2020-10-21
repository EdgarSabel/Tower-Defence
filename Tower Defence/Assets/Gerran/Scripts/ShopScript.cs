using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public int numFirerate,numFreeze,numNuke, healthPlus, numTurretRepairMax;
    int turretRepairNum;
    public float decreaseNum;
    public TextMeshProUGUI numFireRateText, numFreezeText, numNukeText;
    public GameObject money, turret;
    public TextMeshProUGUI itemInfo, cost;
    public AudioSource buySound, notEnoughMoneySound;
    public RaycastHit hit;
    public GameObject shopCam, shopPanel;

    public GameObject player, cam, upgradePanel, menuPanel, waitForNextRoundObj, skipObj;
    public Color normalColor;
    private void Start()
    {
        UpdateNumbers();
    }
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
                        if (turretRepairNum < numTurretRepairMax)
                        {
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                        }
                        else
                        {
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Maxed";
                        }
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
        if (shopCam.activeSelf == false && shopPanel.activeSelf == true)
        {
            shopPanel.SetActive(false);
        }
        if (shopCam.activeSelf == true && shopPanel.activeSelf == false)
        {
            shopPanel.SetActive(true);
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
            UpdateNumbers();
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
            UpdateNumbers();
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
            UpdateNumbers();
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }

    public void BuyTurretRepairSpeed(int prize)
    {
        if(turretRepairNum < numTurretRepairMax)
        {
            if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
            {
                buySound.Play();
                turretRepairNum++;
                turret.GetComponent<TurretRepair>().decreaseNumber -= decreaseNum;
                money.GetComponent<MoneyManager>().GetMoney(-prize);
                UpdateNumbers();
            }
            else
            {
                notEnoughMoneySound.Play();
            }
        }
    }
    public void UpdateNumbers()
    {
        numFireRateText.text = numFirerate.ToString();
        numFreezeText.text = numFreeze.ToString();
        numNukeText.text = numNuke.ToString();
    }
}
