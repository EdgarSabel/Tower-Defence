using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InfoBoxScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject infoPanel;
    private bool mouseover;
    public GameObject[] otherPanels;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseover == true)
        {
            infoPanel.SetActive(true);
            otherPanels[0].SetActive(false);
            otherPanels[1].SetActive(false);
            otherPanels[2].SetActive(false);
            otherPanels[3].SetActive(false);
        }
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
