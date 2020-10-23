using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public int numFirerate,numFreeze,numNuke, healthPlus, numTurretRepairMax, maxHealthBuys;
    int turretRepairNum, healthNum;
    public float decreaseNum;
    public TextMeshProUGUI numFireRateText, numFreezeText, numNukeText;
    public GameObject money, turret, amountText, turretHolder;
    public TextMeshProUGUI itemInfo, cost;
    public AudioSource buySound, notEnoughMoneySound;
    public RaycastHit hit;
    public GameObject shopCam, shopPanel, interactObj;

    public GameObject player, cam, upgradePanel, menuPanel, waitForNextRoundObj, skipObj;
    public Color normalColor;

    public GameObject diceSpawnLoc, currentDice, dicePrefab, diceLoc;
    public bool moveDice, canBuyDice = true;
    public float chanceBullet, chanceFreeze, chanceNuke, speedMove;
    public GameObject instObjHolder, bulletObj, freezeObj, nukeObj;
    private void Start()
    {
        UpdateNumbers();
    }
    void Update()
    {
        if(moveDice == true)
        {
            currentDice.transform.position = Vector3.MoveTowards(currentDice.transform.position, diceLoc.transform.position, speedMove);
            if(currentDice.transform.position == diceLoc.transform.position)
            {
                moveDice = false;
                Destroy(currentDice);
                float randomNumber = Random.Range(0, 100);
                if(randomNumber <= chanceBullet)
                {
                    BuyFirerate(0);
                    Instantiate(bulletObj, instObjHolder.transform);
                }
                else if(randomNumber > chanceBullet && randomNumber <= chanceFreeze)
                {
                    BuyFreeze(0);
                    Instantiate(freezeObj, instObjHolder.transform);
                }
                else if(randomNumber > chanceFreeze && randomNumber <= chanceNuke)
                {
                    BuyNuke(0);
                    Instantiate(nukeObj, instObjHolder.transform);
                }
                else
                {

                }
                StartCoroutine(WaitToDestroyShownItem());
            }
        }

        Ray ray = shopCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (shopCam.activeSelf == true)
        {
            if (Physics.Raycast(ray, out hit, 1000, -5, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.tag == "ShopItem")
                {
                    amountText.SetActive(false);
                    int itemId = hit.collider.gameObject.GetComponent<ItemInShop>().itemId;
                    if (itemId == 1)
                    {
                        if (healthNum < maxHealthBuys) {
                            amountText.SetActive(true);
                            amountText.GetComponent<TextMeshProUGUI>().text = healthNum.ToString() + " / " + maxHealthBuys;
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                        }
                        else
                        {
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Cant buy more";
                        }
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
                            amountText.SetActive(true);
                            amountText.GetComponent<TextMeshProUGUI>().text = turretRepairNum.ToString() + " / " + numTurretRepairMax;
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                        }
                        else
                        {
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Maxed";
                        }
                    }
                    else if (itemId == 7)
                    {
                        if(canBuyDice == true)
                        {
                            itemInfo.text = hit.collider.gameObject.GetComponent<ItemInShop>().itemInfo;
                            cost.text = "Cost: " + hit.collider.gameObject.GetComponent<ItemInShop>().itemCost.ToString();
                        }
                    }
                }
                else
                {
                    itemInfo.text = "";
                    cost.text = "";
                    amountText.SetActive(false);
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
                            interactObj.SetActive(true);

                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = true;
                        }
                        else if (itemId == 7)
                        {
                            if(canBuyDice == true)
                            {
                                StartCoroutine(WaitForDice());
                                BuyDice(hit.collider.gameObject.GetComponent<ItemInShop>().itemCost);
                            }
                        }
                    }
                    amountText.SetActive(false);
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
        if (healthNum < maxHealthBuys)
        {
            if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
            {
                if (money.GetComponent<HealthManager>().health < 120)
                {
                    //give health max health= 120
                    healthNum++;
                    buySound.Play();
                    money.GetComponent<HealthManager>().health += healthPlus;
                    if (money.GetComponent<HealthManager>().health >= 120)
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
                foreach(Transform child in turretHolder.transform)
                {
                    child.GetComponent<TurretRepair>().decreaseNumber -= decreaseNum;
                }
                money.GetComponent<MoneyManager>().GetMoney(-prize);
                UpdateNumbers();
            }
            else
            {
                notEnoughMoneySound.Play();
            }
        }
    }
    void BuyDice(int prize)
    {
        if (money.GetComponent<MoneyManager>().moneyNumber >= prize)
        {
            buySound.Play();
            itemInfo.text = "";
            cost.text = "";
            Instantiate(dicePrefab, diceSpawnLoc.transform);
            currentDice = diceSpawnLoc.transform.GetChild(0).gameObject;
            currentDice.GetComponent<Animator>().SetTrigger("Roll");
            moveDice = true;
            money.GetComponent<MoneyManager>().GetMoney(-prize);
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }
    public void UpdateNumbers()
    {
        numFireRateText.text = numFirerate.ToString();
        numFreezeText.text = numFreeze.ToString();
        numNukeText.text = numNuke.ToString();
    }
    IEnumerator WaitForDice()
    {
        canBuyDice = false;
        yield return new WaitForSeconds(5);
        canBuyDice = true;
    }
    IEnumerator WaitToDestroyShownItem()
    {
        yield return new WaitForSeconds(2);
        foreach(Transform child in instObjHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
