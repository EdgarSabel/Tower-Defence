using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed;
    float moveFb, moveLr;

    public GameObject playerCam, topViewCam;

    bool canMove = false;

    private void Update()
    {
        if(canMove == true)
        {
        moveFb = Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime;
        moveLr = Input.GetAxis("Horizontal") * (walkingSpeed / 2) * Time.deltaTime;

        transform.Translate(moveLr, 0, moveFb);
        }
        //mag later we ↓
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(playerCam.activeSelf == true)
            {
                playerCam.SetActive(false);
                topViewCam.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canMove = false;
            }
            else if(topViewCam.activeSelf == true)
            {
                topViewCam.SetActive(false);
                playerCam.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canMove = true;
            }
        }
        //↑
    }
}
