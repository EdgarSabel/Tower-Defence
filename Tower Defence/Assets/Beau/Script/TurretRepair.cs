using System.ComponentModel;
using UnityEngine;

public class TurretRepair : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource turretKapoetSound, turretMaxRepairedSound;
    }
    public float decreaseNumber;
    [Range(0,100)] public float healthTurret = 100;
    public Material normal, kapoet;
    public Sounds sounds;
    private void Update()
    {
        if (healthTurret > 0)
        {
            healthTurret = Mathf.Clamp(healthTurret, 0, 100);
            healthTurret -= decreaseNumber * Time.deltaTime;
            if (GetComponent<Turret>().enabled != enabled || GetComponent<MeshRenderer>().material != normal)
            {
                this.GetComponent<Turret>().enabled = enabled;
                GetComponent<MeshRenderer>().material = normal;
            }


        }
        else if(healthTurret <= 0)
        {
            //turret kapoet
            healthTurret = 0;
            GetComponent<MeshRenderer>().material = kapoet;
            this.GetComponent<Turret>().enabled = !enabled;
        }
    }
}
