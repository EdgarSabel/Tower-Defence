using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed, jumpHight;
    float moveFb, moveLr;

    [HideInInspector] public bool isGrounded;

    public GameObject playerCam;
    Rigidbody playerRg;
    [HideInInspector] public bool canMove = true;

    private void Start()
    {
        canMove = true;
        playerRg = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveFb = Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime;
        moveLr = Input.GetAxis("Horizontal") * (walkingSpeed /2) * Time.deltaTime;

        if(canMove == true) 
            { 
            transform.Translate(moveLr, 0, moveFb);

            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                playerRg.velocity = new Vector3(0, jumpHight, 0);
            }
        }
    }
}
