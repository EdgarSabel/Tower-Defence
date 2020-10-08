using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource placeTurretSound;
        [HideInInspector] public float placeTurretVolume, placeTurretPitch;
    }

    public GameObject[] turrets;
    public Image[] slots;
    public GameObject cam;
    public Color turretBlackout;
    public float xp1, xp2, xp3;
    public float range;
    private bool turretSpawned;
    public bool isHovering;
    private int currentSlot;
    private GameObject currentTurret;
    public PlayerWeapon playerWeaponScript;
    public Animator animPlayer, animTurret;
    public Sounds sounds;
    public ParticleSystem rangeIndicator;
    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].sprite = turrets[i].GetComponentInChildren<Turret>().invSprite;
        }
        rangeIndicator.transform.localScale = new Vector3(range, 0, range);
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
            playerWeaponScript.canHitByInv = true;
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
        if (rangeIndicator.isPlaying == false)
        {
            rangeIndicator.Play();
            rangeIndicator.transform.gameObject.SetActive(true);
        }
        animPlayer.SetBool("Holding", true);
        playerWeaponScript.canHitByInv = false;
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
                slots[currentSlot].color = turretBlackout;
                turretSpawned = false;
                currentTurret = null;
                isHovering = false;

                sounds.placeTurretSound.volume = Random.Range(sounds.placeTurretVolume - .05f, sounds.placeTurretVolume + .05f);
                sounds.placeTurretSound.pitch = Random.Range(sounds.placeTurretPitch - .1f, sounds.placeTurretPitch + .1f);
                sounds.placeTurretSound.Play();
                rangeIndicator.Stop();
                rangeIndicator.transform.gameObject.SetActive(false);
            }
        }
    }
}
