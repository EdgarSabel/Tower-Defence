using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int playerDmg, repairNumber;
    public float playerWeaponRange, playerWeaponDelay;
    public GameObject cam;

    public GameObject hitMapParticles;

    bool canHit = true;
    RaycastHit hit;

    [System.Serializable]
    public class Sounds
    {
        public AudioSource hitMapSound, hitEnemySound, repairTurretSound;
        [HideInInspector] public float hitmapVolume, hitmapPitch, hitenemyVolume, hitenemyPitch, repairTurretVolume, repairTurretPitch;
    }
    public Sounds sounds;
    private void Start()
    {
        SetUpSounds();
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.localPosition, Vector3.forward);

        //Debug.DrawRay(cam.transform.position, cam.transform.forward * playerWeaponRange, Color.green);

        if (Input.GetButtonDown("Hit") && canHit == true)
        {
            canHit = false;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, playerWeaponRange, -5, QueryTriggerInteraction.Ignore))
            {
                Instantiate(hitMapParticles, hit.point, Quaternion.RotateTowards(Quaternion.identity, this.gameObject.transform.rotation, 1));
                if (hit.transform.tag == "Enemy")
                {
                    print("HitEnemy");
                    hit.transform.GetComponent<Enemy>().GetDamage(playerDmg, true);
                    sounds.hitEnemySound.volume = Random.Range(sounds.hitenemyVolume - .05f, sounds.hitenemyVolume + .05f);
                    sounds.hitEnemySound.pitch = Random.Range(sounds.hitenemyPitch - .1f, sounds.hitenemyPitch + .1f);
                    sounds.hitEnemySound.Play();
                }
                else if(hit.transform.tag == "Turret")
                {
                    print("HitTurret");
                    hit.transform.GetComponent<TurretRepair>().healthTurret += repairNumber;
                    sounds.repairTurretSound.volume = Random.Range(sounds.repairTurretVolume - .05f, sounds.repairTurretVolume + .05f);
                    sounds.repairTurretSound.pitch = Random.Range(sounds.repairTurretPitch - .1f, sounds.repairTurretPitch + .1f);
                    sounds.repairTurretSound.Play();
                }
                else
                {
                    print("HitMap");
                    sounds.hitMapSound.volume = Random.Range(sounds.hitmapVolume - .05f, sounds.hitmapVolume + .05f);
                    sounds.hitMapSound.pitch = Random.Range(sounds.hitmapPitch - .1f, sounds.hitmapPitch + .1f);
                    sounds.hitMapSound.Play();
                }
            }
            StartCoroutine(PlayerWeaponDelay());
        }
    }
    void SetUpSounds()
    {
        sounds.hitenemyVolume = sounds.hitEnemySound.volume;
        sounds.hitenemyPitch = sounds.hitEnemySound.pitch;
        sounds.repairTurretVolume = sounds.repairTurretSound.volume;
        sounds.repairTurretPitch = sounds.repairTurretSound.pitch;
        sounds.hitmapVolume = sounds.hitMapSound.volume;
        sounds.hitmapPitch = sounds.hitMapSound.pitch;
    }
    IEnumerator PlayerWeaponDelay()
    {
        yield return new WaitForSeconds(playerWeaponDelay);
        canHit = true;
    }
}
