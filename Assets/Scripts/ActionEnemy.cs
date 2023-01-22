using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActionEnemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    public float visionRange;

    //attack
    public Transform attackPoint;
    public float attackRange = 1;
    public LayerMask playerLayer;
    private float cooldown = 1;
    float lastHit;
    public int hitPoints = 1;

    //health
    private int maxHealthEnemy = 20;
    private int healthEnemy;

    //hit
    public int speed = 120;


    void Start()
    {
        if (!agent) agent = GetComponent<NavMeshAgent>();
        if (!animator) animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        healthEnemy = maxHealthEnemy;
        agent = GetComponent<NavMeshAgent>();
        lastHit = 0;
    }
    
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude > agent.stoppingDistance)
        {
            //animator.SetFloat("ForwardSpeed", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
            if (Vector3.Distance(transform.position, player.transform.position) > visionRange) return;
            agent.SetDestination(player.transform.position);
        }


        if ((healthEnemy > 0) && ((transform.position - player.transform.position).magnitude <= agent.stoppingDistance))
        {
            AttackSword();
        }
    }


    void AttackSword()
    {

        if (Time.time - lastHit < cooldown && lastHit != 0)
        {
            UnityEngine.Debug.Log("WAIT");
            return;
        }
        UnityEngine.Debug.Log("ATTACK");
        animator.SetTrigger("soldier");


        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider enemy in hitPlayers)
        {
            UnityEngine.Debug.Log(hitPlayers.Length);
            UnityEngine.Debug.Log("We are in the foreach");
            if (!enemy)
            {
                UnityEngine.Debug.Log("THERE IS NO PLAYER");
            }
            else
            {
                UnityEngine.Debug.Log("PLAYER EXISTS");
            }
            enemy.GetComponent<AttackWarrior>().TakeDamagePlayer(2);
            UnityEngine.Debug.Log("Enemy hit");

            //enemyAnimator.SetTrigger("hit");
        }

        lastHit = Time.time;

    }

    public void TakeDamage(int damage)
    {
        healthEnemy -= damage;

        Debug.Log("current health: " + healthEnemy);

        if (healthEnemy <= 0)
        {
            StartCoroutine(Die());
            animator.SetTrigger("dieEnemy");
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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("PUSH");

        Debug.Log("current health: " + healthEnemy);
        yield return null;
    }

    private IEnumerator Die()
    {

        animator.SetTrigger("die");
        Debug.Log("Enemy DEAD");
        yield return new WaitForSeconds(2);
        agent.enabled = false;
        yield return null;

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
