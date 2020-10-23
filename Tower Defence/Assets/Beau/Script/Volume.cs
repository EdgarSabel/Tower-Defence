using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public GameObject faceCube;
    public float extendNumber, maxNumber;
    public CapsuleCollider col;
    private void Start()
    {
        col = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        if(col.radius < maxNumber)
        {
            col.radius += extendNumber * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            faceCube.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            faceCube.SetActive(false);
        }
    }
}
