using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed, jumpHight;
    float moveFb, moveLr;

    [HideInInspector] public bool isGrounded;

    public GameObject playerCam;
    Rigidbody playerRg;
    [HideInInspector] public bool canMove = true;
    public Animator anim;

    public float footstepTimer = .5f;
    public bool isWalkingFb, isWalkingLr, isStraving;
    float footstepBaseVolume, footstepBasePitch;

    [System.Serializable]
    public class Sounds
    {
        public AudioSource walkingSound, jumpSound, landingSound;
    }
    public Sounds sounds;
    private void Start()
    {
        canMove = true;
        playerRg = this.GetComponent<Rigidbody>();
        footstepBaseVolume = sounds.walkingSound.volume;
        footstepBasePitch = sounds.walkingSound.pitch;
    }
    private void Update()
    {
        moveFb = Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime;
        moveLr = Input.GetAxis("Horizontal") * (walkingSpeed /2) * Time.deltaTime;

        if(moveFb != 0 && moveLr == 0)
        {
            isStraving = false;
            isWalkingFb = true;
            isWalkingLr = false;
        }
        else if (moveLr != 0 && moveFb == 0)
        {
            isStraving = false;
            isWalkingFb = false;
            isWalkingLr = true;
        }
        else if (moveFb != 0 && moveLr != 0)
        {
            isStraving = true;
            isWalkingFb = false;
            isWalkingLr = false;
        }
        else if(moveFb != 1 && moveLr != 1)
        {
            isStraving = false;
            isWalkingFb = false;
            isWalkingLr = false;
        }

        if(canMove == true) 
            { 
            transform.Translate(moveLr, 0, moveFb);

            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                //sounds.jumpSound.Play();
                playerRg.velocity = new Vector3(0, jumpHight, 0);
            }
        }

        if(isStraving || isWalkingFb || isWalkingLr)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if(footstepTimer >= -0.0000001 && (isWalkingFb == true || isWalkingLr == true || isStraving == true))
        {
            footstepTimer -= Time.deltaTime;
        }
        else if(footstepTimer <= -0.000001)
        {
            sounds.walkingSound.Play();
            sounds.walkingSound.volume = Random.Range(footstepBaseVolume - .05f, footstepBaseVolume + .05f);
            sounds.walkingSound.pitch = Random.Range(footstepBasePitch - .2f, footstepBasePitch + .2f);
            if (isWalkingFb == true)
            {
                footstepTimer = .5f;
            }
            else if(isWalkingLr == true)
            {
                footstepTimer = .75f;
            }
            else if(isStraving == true)
            {
                footstepTimer = .38f;
            }
        }
    }
}
