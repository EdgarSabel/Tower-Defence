using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpgrade : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject.Find("PlayerManager").GetComponent<SettingsManeger>().Back();
        }
    }
}
