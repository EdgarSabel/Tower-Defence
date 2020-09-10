using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int walkingSpeed, EnemyHealth, EnemyDmg, moneyDropAmount, burnDmg;
    [HideInInspector] public float distTravel;
    [HideInInspector] public float timeAlive;
    public GameObject locationsParentObj, mesh;
    int nextLocNum = 0;
    float lastShotTime;
    [HideInInspector] public float burnRate, burnTimer, duration;
    NavMeshAgent agent;
    GameObject playerManager;
    [HideInInspector]public bool isBurning;
    public bool isFlying, isFalling;
    public Animator anim;
    public Collider collider;

    private void Start()
    {
        SetUpEnemy();
    }
    private void Update()
    {
        timeAlive += Time.deltaTime;
        distTravel = walkingSpeed * timeAlive;
        if(isFlying == true)
        {
            if (isFalling == true && agent.baseOffset > 0.21f)
            {
                agent.baseOffset = Mathf.Clamp(agent.baseOffset, 0.21f, Mathf.Infinity);
                agent.baseOffset -= Time.deltaTime * 16f;
            }
            if(agent.baseOffset <= 0.21f)
            {
                StartCoroutine(Delete());
            }
        }

        if (isBurning == true)
        {
            burnTimer += Time.deltaTime;
            if (burnTimer < duration)
            {
                if (Time.time > lastShotTime + (6.0f / burnRate))
                {
                    GetDamage(burnDmg, false);
                    lastShotTime = Time.time;
                }
            }
        }
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
            Death();
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
    void Death()
    {
        collider.enabled = !enabled;
        agent.speed = 0;
        agent.velocity = new Vector3(0, 0, 0);
        anim.SetTrigger("Dead");
        if (isFlying == true)
        {
            isFalling = true;
        }
        else
        {
            StartCoroutine(Delete());
        }
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
