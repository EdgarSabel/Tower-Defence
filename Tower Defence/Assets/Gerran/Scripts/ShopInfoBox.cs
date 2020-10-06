using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopInfoBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool mouseover;
    public GameObject infoBox,shop;
    public GameObject[] otherInfoBox;
    public Text hpNumText, firerateNumText, freezeNumText, nukeNumText, spikeNumText, iGHpNumText, iGFirerateNumText, iGFreezeNumText, iGNukeNumText, iGSpikeNumText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseover)
        {
            infoBox.SetActive(true);
            otherInfoBox[0].SetActive(false);
            otherInfoBox[1].SetActive(false);
            otherInfoBox[2].SetActive(false);
            otherInfoBox[3].SetActive(false);

        }

        hpNumText.text = shop.GetComponent<ShopScript>().numHP.ToString();
        firerateNumText.text = shop.GetComponent<ShopScript>().numFirerate.ToString();
        freezeNumText.text = shop.GetComponent<ShopScript>().numFreeze.ToString();
        nukeNumText.text = shop.GetComponent<ShopScript>().numNuke.ToString();
        spikeNumText.text = shop.GetComponent<ShopScript>().numSpike.ToString();
        iGHpNumText.text = shop.GetComponent<ShopScript>().numHP.ToString();
        iGFirerateNumText.text = shop.GetComponent<ShopScript>().numFirerate.ToString();
        iGFreezeNumText.text = shop.GetComponent<ShopScript>().numFreeze.ToString();
        iGNukeNumText.text = shop.GetComponent<ShopScript>().numNuke.ToString();
        iGSpikeNumText.text = shop.GetComponent<ShopScript>().numSpike.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseover = false;
    }
}
