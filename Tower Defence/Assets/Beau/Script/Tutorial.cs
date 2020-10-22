using UnityEditor;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject enemyObj;
    bool hasRunned;
    public GameObject[] panels;
    private void Update()
    {
        if(panels[0].activeSelf == true)
        {
            hasRunned = false;
            enemyObj.SetActive(true);
        }
        else if(hasRunned == false)
        {
            hasRunned = true;
            enemyObj.SetActive(false);
        }
    }
    public void ToTheLeft(int currentPanel)
    {
        if (currentPanel > 0)
        {
            foreach (GameObject g in panels)
            {
                g.SetActive(false);
                panels[currentPanel - 1].SetActive(true);
            }
        }
    }
    public void ToTheRight(int currentPanel)
    {
        if (currentPanel < panels.Length)
        {
            foreach(GameObject g in panels)
            {
                g.SetActive(false);
                panels[currentPanel + 1].SetActive(true);
            }
        }
    }
}
