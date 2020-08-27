using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float walkingSpeed, EnemyHealth, EnemyDmg;
    public float distTravel;
    public float timeAlive;
    public GameObject locationsParentObj;
    int nextLocNum = 0;
    NavMeshAgent agent;

    private void Start()
    {
        SetUpEnemy();
    }
    private void Update()
    {
        timeAlive += Time.deltaTime;
        distTravel = walkingSpeed * timeAlive;
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("do damge to enemy");
            GetDamage(1);
        }
    }
    public void SetUpEnemy()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkingSpeed;

        locationsParentObj = GameObject.Find("Locations");

        agent.SetDestination(locationsParentObj.transform.GetChild(0).transform.position);
    }
    public void GetDamage(float dmg)
    {
        EnemyHealth -= dmg;
        if(EnemyHealth <= 0)
        {
            //play death anim
            Destroy(gameObject);
        }
    }
    public void SetNextLoc()
    {
        if(nextLocNum < locationsParentObj.transform.childCount - 1)
        {
            nextLocNum++;
            agent.SetDestination(locationsParentObj.transform.GetChild(nextLocNum).transform.position);
        }
        else
        {
            print("Do " + EnemyDmg + " to player base");
            Destroy(gameObject);
        }
    }
}
