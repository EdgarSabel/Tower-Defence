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
    private void Update()
    {
        foreach(Transform child in this.gameObject.transform)
        {
            if (child.GetComponent<ParticleSystem>().isStopped)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
