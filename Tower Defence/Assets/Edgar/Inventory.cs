﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public GameObject cam, turretPLText, turretPUText;
    public Color turretBlackout;
    public float xp1, xp2, xp3;
    public float range;
    private bool turretSpawned;
    public bool isHovering, lookAtPath, isOnPath;
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
        RefreshTurretLevel();
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
        if (Input.GetButtonDown("Slot1") && turrets[0] != null && isHovering == false)
        {
            isHovering = true;
            currentSlot = 0;
        }
        if (Input.GetButtonDown("Slot2") && turrets[1] != null && isHovering == false)
        {
            isHovering = true;
            currentSlot = 1;
        }
        if (Input.GetButtonDown("Slot3") && turrets[2] != null && isHovering == false)
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
            turretPLText.SetActive(true);
            turretPUText.SetActive(false);
            if (hit.transform.gameObject.tag == "Ground")
            {
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, range, 1 << 9))
                {
                    lookAtPath = true;
                }
                else if(lookAtPath == true)
                {
                    lookAtPath = false;
                }
                if (lookAtPath == false)
                {
                    currentTurret.transform.position = hit.point;
                }
            }
            if (turretSpawned == false)
            {
                currentTurret.SetActive(true);
                currentTurret.GetComponent<BoxCollider>().enabled = !enabled;
                currentTurret.GetComponentInChildren<Turret>().enabled = !enabled;
                currentTurret.GetComponentInChildren<TurretRepair>().enabled = !enabled;
                turretSpawned = true;
            }
            if (Input.GetButtonDown("Fire1") && lookAtPath == false)
            {
                PlaceTurret();
            }
        if (Input.GetButtonDown("Fire2"))
        {
                turretPLText.SetActive(false);
                currentTurret.SetActive(false);
                rangeIndicator.Stop();
                rangeIndicator.transform.gameObject.SetActive(false);
                currentTurret = null;
                turretSpawned = false;
                isHovering = false;
        }
        }
    }
    public void PlaceTurret()
    {
        currentTurret.GetComponentInChildren<Turret>().enabled = enabled;
        currentTurret.GetComponentInChildren<TurretRepair>().enabled = enabled;
        currentTurret.GetComponent<BoxCollider>().enabled = enabled;
        currentTurret.GetComponent<Animator>().SetTrigger("Place");
        turrets[currentSlot] = null;
        slots[currentSlot].color = turretBlackout;
        turretSpawned = false;
        currentTurret = null;
        turretPLText.SetActive(false);
        isHovering = false;

        sounds.placeTurretSound.volume = Random.Range(sounds.placeTurretVolume - .05f, sounds.placeTurretVolume + .05f);
        sounds.placeTurretSound.pitch = Random.Range(sounds.placeTurretPitch - .1f, sounds.placeTurretPitch + .1f);
        sounds.placeTurretSound.Play();
        rangeIndicator.Stop();
        rangeIndicator.transform.gameObject.SetActive(false);
    }
    public GameObject turretHolder;
    public TextMeshProUGUI[] turretLevels;
    public void RefreshTurretLevel()
    {
        int turretLevel;
        for (int f = 0; f < turrets.Length; f++)
        {
            turretLevel = turretHolder.transform.GetChild(f).GetComponentInChildren<Turret>().turretLevel;
            turretLevel += 1;
            turretLevels[f].text = "Lv " + turretLevel.ToString();
        }
    }
}
