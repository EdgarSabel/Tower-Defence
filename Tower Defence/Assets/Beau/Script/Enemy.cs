using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int walkingSpeed, EnemyHealth, EnemyDmg, moneyDropAmount, burnDmg;
    [HideInInspector] public float distTravel;
    [HideInInspector] public float timeAlive;
    public GameObject locationsParentObj, mesh, freezeParticlesParent;
    int nextLocNum = 0;
    float lastShotTime;
    [HideInInspector] public float burnRate,zapTimer, zapDur, burnTimer, duration;
    NavMeshAgent agent;
    GameObject playerManager;
    [HideInInspector]public bool isBurning;
    public bool isFlying, isFalling, isZapped;
    public Animator anim;
    public Collider enemyCollider;
    public ParticleSystem burn, lightning;
    public bool burnIsAlreadyOn, zapIsAlreadyOn;
    [System.Serializable]
        public class Sounds
        {
            public AudioSource walkingSound, getHitSound, deathSound;
        }
    public Sounds sounds;
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
            if (isFalling == true && transform.position.y > -0.34f)
            {
                Vector3 pos = transform.position;
                pos.y = Mathf.Clamp(pos.y, -0.34f, Mathf.Infinity);
                pos.y -= Time.deltaTime * 16f;
                transform.position = pos;
            }
            if(transform.position.y <= -0.34f)
            {
                StartCoroutine(Delete());
            }
        }

        if (isZapped == true)
        {
            zapTimer += Time.deltaTime;
            if (zapTimer >= zapDur)
            {
                lightning.Stop();
                agent.speed = walkingSpeed;
                zapTimer = 0;
                isZapped = false;
            }
            else
            {
                lightning.Play();
                agent.speed = 0;
            }
        }

        if (isBurning == true)
        {
            if (burnIsAlreadyOn == false)
            {
                burnIsAlreadyOn = true;
                burn.Play();
            }
            burnTimer += Time.deltaTime;
            if (burnTimer < duration)
            {
                if (Time.time > lastShotTime + (6.0f / burnRate))
                {
                    if (EnemyHealth > 0)
                    {
                    GetDamage(burnDmg, true);
                    }
                    lastShotTime = Time.time;
                }
            }
            else
            {
                isBurning = false;
            }
        }
        else if(burnIsAlreadyOn == true)
        {
            burnIsAlreadyOn = false;
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
        enemyCollider.enabled = !enabled;
        agent.speed = 0;
        agent.velocity = new Vector3(0, 0, 0);
        agent.enabled = !enabled;
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
    public void FreezeAbil(int freezeTime)
    {
        StartCoroutine(Freeze(freezeTime));
    }
    IEnumerator Freeze(int timeFreezed)
    {
        foreach (Transform child in freezeParticlesParent.transform)
        {
            agent.speed = walkingSpeed;
            agent.speed /= 2f;
            child.GetComponent<ParticleSystem>().Play();
        }
        yield return new WaitForSeconds(timeFreezed);
        foreach (Transform child in freezeParticlesParent.transform)
        {
            agent.speed = walkingSpeed;
            child.GetComponent<ParticleSystem>().Stop();
        }
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
