using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class AttackWarrior : MonoBehaviour
{
    //[SerializeField] public NavMeshAgent agent;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator animator;
    //[SerializeField] public Animator enemyAnimator;

    //varaibles used to attack
    //private int rotSpeed = 40000;
    private float cooldownHit = 1;
    private float cooldownJump = 5;
    private float cooldownSpin = 5;
    float lastHit;
    float lastJump;
    float lastSpin;
    bool spin = false;

    //variables used to touch enemy
    public Transform attackpoint;
    public Transform blastpoint;
    public float attackRange = 1;
    public float jumpRange = 3;
    public LayerMask enemyLayer;
    public int damageHit = 5;
    public int damageJump = 2;
    public int damageSpin = 1;

    //health
    private int maxHealth = 100;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
        //animator = GetComponentInChildren<Animator>();
        lastHit = 0;
        lastJump = 0;
        lastSpin = 0;

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackSword();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            AttackJump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(AttackSpin());

        }
    }

    void AttackSword()
    {
        if (Time.time - lastHit < cooldownHit && lastHit != 0)
        {
            UnityEngine.Debug.Log("WAIT");
            return;
        }
        UnityEngine.Debug.Log("ATT ACK");
        animator.SetTrigger("Attack");

        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<ActionEnemy>().TakeDamage(damageHit);
            UnityEngine.Debug.Log("Swing hit");

            //enemyAnimator.SetTrigger("hit");
        }

        lastHit = Time.time;
    }

    void AttackJump()
    {
        if (Time.time - lastJump < cooldownJump && lastJump != 0)
        {
            UnityEngine.Debug.Log("WAIT");
            return;
        }
        UnityEngine.Debug.Log("JUMP");
        animator.SetTrigger("Jump");

        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayer);
        Collider[] blastEnemies = Physics.OverlapSphere(blastpoint.position, jumpRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<ActionEnemy>().TakeDamage(damageJump);
            UnityEngine.Debug.Log("Jump hit");
            enemy.GetComponent<ActionEnemy>().PushBack();


            //enemyAnimator.SetTrigger("hit");
        }

        lastJump = Time.time;
    }

    IEnumerator AttackSpin()
    {
        if (Time.time - lastSpin < cooldownSpin && lastSpin != 0)
        {
            UnityEngine.Debug.Log("WAIT");
            yield break;
        }

        animator.SetTrigger("spin");

        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<ActionEnemy>().TakeDamage(damageSpin);
            UnityEngine.Debug.Log("Spin hit");

            //enemyAnimator.SetTrigger("hit");
        }
        /*UnityEngine.Debug.Log("SPIN");
        float startTime = 0;
        while (startTime < 3)
        {
            transform.Rotate(new UnityEngine.Vector3(0f, rotSpeed * Time.deltaTime, 0f) * Time.deltaTime);
            startTime += Time.deltaTime;
            yield return null;

        }
        lastHit = Time.time;
        UnityEngine.Debug.Log("SPIN FINISHED");*/

        lastSpin = Time.time;
    }


    public void TakeDamagePlayer(int damage)
    {
        UnityEngine.Debug.Log("We ENTERED TAKEDAMAGEPLAYER");
        health -= damage;

        UnityEngine.Debug.Log("current health player: " + health);

        if (health <= 0)
        {
            StartCoroutine(Die());
            animator.SetTrigger("die");
        }

    }

    private IEnumerator Die()
    {

        animator.SetTrigger("die");
        UnityEngine.Debug.Log("PLAYER DEAD");
        yield return null;

    }

    /*void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        { 
            return;
        }
        Gizmos.DrawSphere(attackpoint.position, attackRange);
    }*/

    void OnDrawGizmosSelected()
    {
        if (blastpoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(blastpoint.position, jumpRange);
    }


}  

