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

    public float footstepTimer = .5f;
    public bool isWalking;

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
    }
    private void Update()
    {
        moveFb = Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime;
        moveLr = Input.GetAxis("Horizontal") * (walkingSpeed /2) * Time.deltaTime;

        if(moveFb != 0 || moveLr != 0)
        {
            isWalking = true;
        }
        else if(moveFb != 1 || moveLr != 1)
        {
            isWalking = false;
            footstepTimer = .5f;
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

        if(footstepTimer >= -0.0000001 && isWalking == true)
        {
            footstepTimer -= Time.deltaTime;
        }
        else if(footstepTimer <= -0.000001)
        {
            sounds.walkingSound.Play();
            footstepTimer = .5f;
        }
    }
}
