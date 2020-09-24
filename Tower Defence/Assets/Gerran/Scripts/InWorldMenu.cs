﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InWorldMenu : MonoBehaviour
{
    public GameObject inGameMenuPanel, turretNeedsRepair, turret;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(GetComponent<DetectTurret>().turret.transform.position);
        transform.position = namePos;
        //turretNeedsRepair.transform.position = namePos;

        //if (turret.GetComponent<TurretRepair>().healthTurret <= 0)
        //{
        //    turretNeedsRepair.SetActive(true);
        //}

        //else
        //{
        //    turretNeedsRepair.SetActive(false);
        //}
    }

    
}
