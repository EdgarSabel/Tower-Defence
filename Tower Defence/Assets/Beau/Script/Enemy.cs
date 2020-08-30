using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int walkingSpeed, EnemyHealth, EnemyDmg, moneyDropAmount;
    [HideInInspector] public float distTravel;
    [HideInInspector] public float timeAlive;
    public GameObject locationsParentObj;
    int nextLocNum = 0;
    NavMeshAgent agent;
    GameObject playerManager;
    public bool isFlying;

    private void Start()
    {
        SetUpEnemy();
    }
    private void Update()
    {
        timeAlive += Time.deltaTime;
        distTravel = walkingSpeed * timeAlive;
    }
    public void SetUpEnemy()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkingSpeed;

        locationsParentObj = GameObject.Find("Locations");
        playerManager = GameObject.Find("PlayerManager");

        agent.SetDestination(locationsParentObj.transform.GetChild(0).transform.position);
    }
    public void GetDamage(int dmg, bool doGiveMoney)
    {
        EnemyHealth -= dmg;
        if(EnemyHealth <= 0)
        {
            if(doGiveMoney == true)
            {
                playerManager.GetComponent<MoneyManager>().GetMoney(moneyDropAmount);
            }
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
            Destroy(gameObject);
            playerManager.GetComponent<HealthManager>().GetDamagedByEnemy(EnemyDmg);
        }
    }
}
