using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerFlame : MonoBehaviour
{
    public FlameThrowerTurret turret;
    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponentInParent<FlameThrowerTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {        
        if (other.gameObject.tag == "Enemy")
        {
            print("DAMAGE");
            other.GetComponent<Enemy>().GetDamage(turret.damage, true);
        }
    }
}
