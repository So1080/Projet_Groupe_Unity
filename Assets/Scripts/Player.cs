using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected float lastHit1;
    protected float lastHit2;
    protected float lastHit3;
    protected int coolDownHit1;
    protected int coolDownHit2;
    protected int coolDownHit3;
    public int damageHit1;
    public int damageHit2;
    public int damageHit3;

    //deplacer
    public Rigidbody rb;
    protected float verInput;
    protected float horInput;

    // Start is called before the first frame update
    void Start()
    {
        lastHit1 = 0;
        lastHit2 = 0;
        lastHit3 = 0;

        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
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

    protected void InflictDamage(Transform attackpoint, float attackRange, LayerMask enemyLayer, int damage)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<NPC>().TakeDamage(damage);
            UnityEngine.Debug.Log("Spin hit");
        }
    }


    protected void run(float horInput, float verInput)
    {
        Debug.Log("run");
        rb.velocity = new Vector3(horInput, 0, verInput).normalized * speed;
        Debug.Log(new Vector3(horInput, 0, verInput).normalized * speed);
    }

    protected void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);


        }


    }

}
