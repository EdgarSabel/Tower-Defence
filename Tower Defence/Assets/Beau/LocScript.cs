using UnityEngine;

public class LocScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().SetNextLoc();
        }
    }
}
