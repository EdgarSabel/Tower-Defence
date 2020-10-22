using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLoadout : MonoBehaviour
{
    public GameObject emptyObj;
    static public int[] turrets = new int[3]; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(emptyObj);
    }
}
