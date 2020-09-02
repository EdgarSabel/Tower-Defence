using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{
    public float sensetivity;
    public GameObject playerObj;

    float mouseX, MouseY;
    float xRotation;
    [HideInInspector] public bool canMove;

    private void Start()
    {
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(canMove == true)
        {
            mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
            MouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -80, 80);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerObj.transform.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetButtonDown("Cancel")) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
