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
        if(other.gameObject.tag != "Enemy")
        {
            if(other.isTrigger == false)
            transform.parent.GetComponent<PlayerMovement>().walkingSpeed = 6;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag != "Enemy")
        {
            if (other.isTrigger == false)
                transform.parent.GetComponent<PlayerMovement>().walkingSpeed = normalWalkingSpeed;
        }
    }
}
