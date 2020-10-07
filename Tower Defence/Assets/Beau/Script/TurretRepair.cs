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
    public ParticleSystem boostParticles;
    public Sounds sounds;
    bool runSoundOnce;
    private void Update()
    {
        if(healthTurret >= 100)
        {
            sounds.turretMaxRepairedSound.Play();
        }
        if (healthTurret > 0)
        {
            healthTurret = Mathf.Clamp(healthTurret, 0, 100);
            healthTurret -= decreaseNumber * Time.deltaTime;
            if (turretScript.enabled != enabled)
            {
                sounds.turretKapoetSound.Stop();
                runSoundOnce = false;
                anim.SetBool("IsBroken", false);
                anim.SetTrigger("Repair");
                turretScript.enabled = enabled;
            }
        }
        else if(healthTurret <= 0)
        {
            healthTurret = 0;
            anim.SetBool("IsBroken", true);
            turretScript.enabled = !enabled;
            if(runSoundOnce == false)
            {
                runSoundOnce = true;
                sounds.turretKapoetSound.Play();
            }
        }
    }
}