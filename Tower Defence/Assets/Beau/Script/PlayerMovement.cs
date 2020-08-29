using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed, jumpHight;
    float moveFb, moveLr;

    [HideInInspector] public bool isGrounded;

    public GameObject playerCam;
    Rigidbody playerRg;

    private void Start()
    {
        playerRg = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveFb = Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime;
        moveLr = Input.GetAxis("Horizontal") * (walkingSpeed /2) * Time.deltaTime;

        transform.Translate(moveLr, 0, moveFb);

        //Vector3 movement = new Vector3(moveLr, 0, moveFb);
        //playerRg.velocity = transform.TransformDirection(movement * walkingSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRg.velocity = new Vector3(0, jumpHight, 0);
        }
    }
}
