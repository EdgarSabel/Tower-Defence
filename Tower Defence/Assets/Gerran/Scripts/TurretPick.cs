using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPick : MonoBehaviour
{
    public int slotNum;
    public Sprite normal, shotgun, flame, electric, canon;
    public Image[] slots;
    public GameObject turrets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNormal()
    {
        TurretLoadout.turrets[slotNum] = 0;
        slots[slotNum].sprite = normal;
        if(slotNum == 2)
        {
            slotNum = 0;
        }

        else if(slotNum <= 2)
        {
            slotNum += 1;
        }
    }

    public void SelectShotgun()
    {
        TurretLoadout.turrets[slotNum] = 1;
        slots[slotNum].sprite = shotgun;
        if (slotNum == 2)
        {
            slotNum = 0;
        }

        else if (slotNum <= 2)
        {
            slotNum += 1;
        }
    }
    public void SelectFlame()
    {
        TurretLoadout.turrets[slotNum] = 2;
        slots[slotNum].sprite = flame;
        if (slotNum == 2)
        {
            slotNum = 0;
        }

        else if (slotNum <= 2)
        {
            slotNum += 1;
        }
    }

    public void SelectElectic()
    {
        TurretLoadout.turrets[slotNum] = 3;
        slots[slotNum].sprite = electric;
        if (slotNum == 2)
        {
            slotNum = 0;
        }

        else if (slotNum <= 2)
        {
            slotNum += 1;
        }
    }
    public void SelectCanon()
    {
        TurretLoadout.turrets[slotNum] = 4;
        slots[slotNum].sprite = canon;
        if (slotNum == 2)
        {
            slotNum = 0;
        }

        else if (slotNum <= 2)
        {
            slotNum += 1;
        }
    }

}
