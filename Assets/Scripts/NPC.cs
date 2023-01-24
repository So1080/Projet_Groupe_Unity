using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Character
{
    protected int hitpoints;
    public GameObject player;
    public NavMeshAgent agent;
    protected float lastHit;
    public float visionRange;
    protected int cooldown = 1;
    public int hitPoints = 2;
    public int speedBlast = 120;
    private UnityEngine.Vector3 xp_pos;
    public GameObject xp;
    private GameObject xpDie;


    //healthbar
    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start() 
    {
        if (!agent) agent = GetComponent<NavMeshAgent>();
        if (!animator) animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        lastHit = 0;
        visionRange = 100;

        healthBar.UpdateHealthBar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FollowPlayer()
    {
        //Debug.Log("TRANSFORM POSITION " + transform.position);
        //Debug.Log("TRANSFORM POSITION PLAYER " + player.transform.position);
        //Debug.Log("TRANSFORM POSITION " + transform.position);
        //Debug.Log("AGENT STOPPING DISTANCE " + agent.stoppingDistance);
        if ((transform.position - player.transform.position).magnitude > agent.stoppingDistance)
        {
            //animator.SetFloat("ForwardSpeed", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
            if (UnityEngine.Vector3.Distance(transform.position, player.transform.position) > visionRange) return;
            agent.SetDestination(player.transform.position);
            animator.SetFloat("ForwardSpeed", agent.velocity.magnitude / agent.speed);

        }
        transform.rotation = UnityEngine.Quaternion.LookRotation(player.transform.position - transform.position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("current health ENEMY: " + health);

        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            StartCoroutine(Die());

        }
        else
        {
            animator.SetTrigger("hitEnemy");
        }

    }

    public void PushBack()
    {
        StartCoroutine(PushBackCo());
    }

    IEnumerator PushBackCo()
    {
        Debug.Log("WAIT A SECOND");
        yield return new WaitForSeconds(1);
        transform.Translate(UnityEngine.Vector3.forward * speedBlast * Time.deltaTime);
        Debug.Log("PUSH");

        Debug.Log("current health: " + health);
        yield return null;
    }

    public void InflictDamage(Transform attackpoint, float attackRange, LayerMask enemyLayer, int damage)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Player>().TakeDamage(damage);
            UnityEngine.Debug.Log("Spin hit");
        }
    }

    public IEnumerator Die()
    {
        Debug.Log(gameObject.name);
        Debug.Log(character.name);
        animator.SetTrigger("die");
        Debug.Log("Enemy DEAD");
        yield return new WaitForSeconds(1);
        xp_pos = transform.position;
        Instantiate(xp, xp_pos, UnityEngine.Quaternion.identity);
        Debug.Log(xp);
        Destroy(gameObject);
        yield return null;

    }
}
