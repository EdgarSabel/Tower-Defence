using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Sounds
    {
        public AudioSource placeTurretSound, pickupTurretSound;
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
    private Vector3 offset = new Vector3(0, (float)0.5, 0);
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
        if (Input.GetButtonDown("Slot2") && turrets[0] != null)
        {
            isHovering = true;
            currentSlot = 0;
        }
        if (Input.GetButtonDown("Slot3") && turrets[1] != null)
        {
            isHovering = true;
            currentSlot = 1;
        }
        if (Input.GetButtonDown("Slot4") && turrets[2] != null)
        {
            isHovering = true;
            currentSlot = 2;
        }
    }

    public void Hover()
    {
        currentTurret = turrets[currentSlot];
        RaycastHit hit;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * range, Color.red);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit ,range, -5, QueryTriggerInteraction.Ignore))
        {
            if (hit.transform.gameObject.tag == "Ground")
            {
                currentTurret.transform.position = hit.point + offset;
            }
            if (turretSpawned == false)
            {
                currentTurret.SetActive(true);
                currentTurret.GetComponent<BoxCollider>().enabled = !enabled;
                currentTurret.GetComponent<Turret>().enabled = !enabled;
                currentTurret.GetComponent<TurretRepair>().enabled = !enabled;
                turretSpawned = true;
            }
            if (Input.GetButtonDown("Interact"))
            {
                currentTurret.GetComponent<Turret>().enabled = enabled;
                currentTurret.GetComponent<TurretRepair>().enabled = enabled;
                currentTurret.GetComponent<BoxCollider>().enabled = enabled;
                turrets[currentSlot] = null;
                turretSpawned = false;
                isHovering = false;

                sounds.placeTurretSound.volume = Random.Range(sounds.placeTurretVolume - .05f, sounds.placeTurretVolume + .05f);
                sounds.placeTurretSound.pitch = Random.Range(sounds.placeTurretPitch - .1f, sounds.placeTurretPitch + .1f);
                sounds.placeTurretSound.Play();
            }
        }
    }
}
