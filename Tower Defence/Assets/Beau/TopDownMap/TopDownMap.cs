using UnityEngine;

public class TopDownMap : MonoBehaviour
{
    public GameObject map, mapImage, player, playerSprite;
    public float speedMove;


    private void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            if (map.activeSelf == false)
            {
                playerSprite.transform.localPosition = new Vector3(player.transform.position.x * speedMove, player.transform.position.z * speedMove);

                player.GetComponent<PlayerMovement>().canMove = false;
                player.GetComponentInChildren<CamLook>().canMove = false;
                map.SetActive(true);
            }
            else if(map.activeSelf == true)
            {
                player.GetComponent<PlayerMovement>().canMove = true;
                player.GetComponentInChildren<CamLook>().canMove = true;
                map.SetActive(false);
            }
        }
    }
}
