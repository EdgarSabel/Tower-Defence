using UnityEngine;

public class IsGroundedCheck : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMovement>().isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMovement>().isGrounded = false;
    }
}
