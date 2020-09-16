using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxScript : MonoBehaviour
{

    public bool isHovering;
    public GameObject infoBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHovering == true)
        {
            infoBox.SetActive(true);
        }

        else if(isHovering == false)
        {
            infoBox.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        isHovering = true;
    }

    private void OnMouseExit()
    {
        isHovering = false;
    }
}
