using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
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
        if(other.gameObject.tag == "Enemy")
        {
            return;
        }
        else if (other.gameObject.tag == "Turret")
        {
            return;
        }
        print(other.gameObject.tag);
        if (other.isTrigger == false)
            transform.parent.GetComponent<PlayerMovement>().walkingSpeed = 6;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            return;
        }
        else if (other.gameObject.tag == "Turret")
        {
            return;
        }
        print(other.gameObject.tag);
        if (other.isTrigger == false)
            transform.parent.GetComponent<PlayerMovement>().walkingSpeed = normalWalkingSpeed;
    }
}
