using UnityEngine;

public class LocScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().SetNextLoc();
        }
        else if(other.gameObject.transform.parent.tag == "Enemy")
        {
            other.transform.parent.GetComponent<Enemy>().SetNextLoc();
        }
    }
}
