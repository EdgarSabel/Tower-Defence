using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCol : MonoBehaviour
{
    float normalWalkingSpeed;
    private void Start()
    {
        normalWalkingSpeed = transform.parent.GetComponent<PlayerMovement>().walkingSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<PlayerMovement>().walkingSpeed = 6;
    }
    private void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<PlayerMovement>().walkingSpeed = normalWalkingSpeed;
    }
}
