using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLoadout : MonoBehaviour
{
    public GameObject emptyObj;
    public int[] turrets;
    public GameObject[] prefabs; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(emptyObj);

        Camera.main.GetComponentInParent<Inventory>().turrets[0] = prefabs[turrets[0]];
        Camera.main.GetComponentInParent<Inventory>().turrets[1] = prefabs[turrets[1]];
        Camera.main.GetComponentInParent<Inventory>().turrets[2] = prefabs[turrets[2]];
    }
}
