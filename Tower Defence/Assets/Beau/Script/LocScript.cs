using UnityEngine;

public class LocScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Test");
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().SetNextLoc();
        }
    }
}
