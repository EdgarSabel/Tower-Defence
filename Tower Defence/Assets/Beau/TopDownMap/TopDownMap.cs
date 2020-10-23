using UnityEngine;

public class TopDownMap : MonoBehaviour
{
    public GameObject map;
    public float speedMove;


    private void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            if (map.activeSelf == false)
            {
                map.SetActive(true);
            }
            else if(map.activeSelf == true)
            {
                map.SetActive(false);
            }
        }
    }
}
