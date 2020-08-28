using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ParticleSystemScripts : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        this.transform.LookAt(player.transform);
    }
    /*
    private void Update()
    {
        if(this.GetComponent<ParticleSystem>().isStopped == true)
        {
            Destroy(gameObject);
        }
    }*/
}
