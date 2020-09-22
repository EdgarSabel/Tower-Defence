using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations;

public class TurretRepair : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource turretKapoetSound, turretMaxRepairedSound;
    }
    public float decreaseNumber;
    [Range(0,100)] public float healthTurret = 100;
    public Turret turretScript;
    public Animator anim;
    public Sounds sounds;
    private void Update()
    {
        if (healthTurret > 0)
        {
            healthTurret = Mathf.Clamp(healthTurret, 0, 100);
            healthTurret -= decreaseNumber * Time.deltaTime;
            if (turretScript.enabled != enabled)
            {
                anim.SetTrigger("Repair");
                this.GetComponent<Turret>().enabled = enabled;
            }
        }
        else if(healthTurret <= 0)
        {
            //turret kapoet
            healthTurret = 0;
            anim.SetTrigger("Break");
            turretScript.enabled = !enabled;
        }
    }
}