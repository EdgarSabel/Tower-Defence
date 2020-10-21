using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBall : MonoBehaviour
{
    public int damage;
    public float speed;
    private float timer;
    public GameObject target;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.Find("HitLoc").transform.position, speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().GetDamage(damage, true);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
