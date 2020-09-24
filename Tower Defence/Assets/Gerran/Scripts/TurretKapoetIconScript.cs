using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretKapoetIconScript : MonoBehaviour
{

    public GameObject turretNeedsRepair, turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (turret.GetComponent<TurretRepair>().healthTurret <= 0.000001)
        {
            turretNeedsRepair.SetActive(true);
        }

        else
        {
            turretNeedsRepair.SetActive(false);
        }
        transform.LookAt(Camera.main.transform);
    }
}
