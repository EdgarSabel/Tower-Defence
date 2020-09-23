using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource placeTurretSound;
        [HideInInspector] public float placeTurretVolume, placeTurretPitch;
    }

    public GameObject[] turrets;
    public float range;
    private int currentSlot;
    public bool isHovering;
    private bool turretSpawned;
    public GameObject cam;
    private GameObject currentTurret;
    public float xp1, xp2, xp3;
    public PlayerWeapon playerWeaponScript;
    public Animator animPlayer, animTurret;
    public Sounds sounds;
    private void Start()
    {
        cam = GameObject.Find("Camera");
        sounds.placeTurretVolume = sounds.placeTurretSound.volume;
        sounds.placeTurretPitch = sounds.placeTurretSound.pitch;
    }
    private void Update()
    {
        if (isHovering == true)
        {
            Hover();
        }
        else
        {
            animPlayer.SetBool("Holding", false);
            playerWeaponScript.canHit = true;
        }
        if (Input.GetButtonDown("Slot2") && turrets[0] != null && isHovering == false)
        {
            isHovering = true;
            currentSlot = 0;
        }
        if (Input.GetButtonDown("Slot3") && turrets[1] != null && isHovering == false)
        {
            isHovering = true;
            currentSlot = 1;
        }
        if (Input.GetButtonDown("Slot4") && turrets[2] != null && isHovering == false)
        {
            isHovering = true;
            currentSlot = 2;
        }
    }

    public void Hover()
    {
        animPlayer.SetBool("Holding", true);
        playerWeaponScript.canHit = false;
        if (currentTurret == null)
        {
            currentTurret = turrets[currentSlot];
        }
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit ,range, -5, QueryTriggerInteraction.Ignore))
        {
            if (hit.transform.gameObject.tag == "Ground")
            {
                currentTurret.transform.position = hit.point;
            }
            if (turretSpawned == false)
            {
                currentTurret.SetActive(true);
                currentTurret.GetComponent<BoxCollider>().enabled = !enabled;
                currentTurret.GetComponentInChildren<Turret>().enabled = !enabled;
                currentTurret.GetComponentInChildren<TurretRepair>().enabled = !enabled;
                turretSpawned = true;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                currentTurret.GetComponentInChildren<Turret>().enabled = enabled;
                currentTurret.GetComponentInChildren<TurretRepair>().enabled = enabled;
                currentTurret.GetComponent<BoxCollider>().enabled = enabled;
                currentTurret.GetComponent<Animator>().SetTrigger("Place");
                turrets[currentSlot] = null;
                turretSpawned = false;
                currentTurret = null;
                isHovering = false;

                sounds.placeTurretSound.volume = Random.Range(sounds.placeTurretVolume - .05f, sounds.placeTurretVolume + .05f);
                sounds.placeTurretSound.pitch = Random.Range(sounds.placeTurretPitch - .1f, sounds.placeTurretPitch + .1f);
                sounds.placeTurretSound.Play();
            }
        }
    }

    public void Upgrade()
    {

    }
}
