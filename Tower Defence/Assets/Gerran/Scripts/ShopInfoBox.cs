using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopInfoBox : MonoBehaviour
{
    public GameObject[] panels;
    public void OnHover(GameObject itemPanel)
    {
        foreach(GameObject g in panels)
        {
            g.SetActive(false);
        }
        itemPanel.SetActive(true);
    }
    public void OnHoverExit()
    {
        foreach (GameObject g in panels)
        {
            g.SetActive(false);
        }
    }
}
