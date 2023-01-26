using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Player : Character
{
    protected float lastHit1;
    protected float lastHit2;
    protected float lastHit3;
    [System.NonSerialized] public int coolDownHit1;
    [System.NonSerialized] public int coolDownHit2;
    [System.NonSerialized] public int coolDownHit3;
    [System.NonSerialized] public int damageHit1;
    [System.NonSerialized] public int damageHit2;
    [System.NonSerialized] public int damageHit3;
    [System.NonSerialized] public bool tookDamage;
    [System.NonSerialized] public int damages;

    //deplacer
    public Rigidbody rb;
    protected float verInput;
    protected float horInput;


    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        lastHit1 = 0;
        lastHit2 = 0;
        lastHit3 = 0;

        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

        tookDamage = false;

        healthBar.UpdateHealthBar(health, maxHealth);
    }

    void Update()
    {
        if (health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) Attack1();

            if (Input.GetKeyDown(KeyCode.J)) Attack2();

            if (Input.GetKeyDown(KeyCode.K)) Attack3();

            horInput = Input.GetAxis("Horizontal");
            verInput = Input.GetAxis("Vertical");
            //animator.SetFloat("ver_input", verInput);
            //animator.SetFloat("hor_input", horInput);

            run(horInput, verInput);

            LookAtMouse();
        }
    }

    public abstract void Attack1();

    public abstract void Attack2();

    public abstract void Attack3();

    public void TakeDamage(int damage)
    {
        //UnityEngine.Debug.Log("We ENTERED TAKEDAMAGEPLAYER");
        health -= damage;

        //UnityEngine.Debug.Log("current health player: " + health);
        tookDamage = true;
        damages = damage;

        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            StartCoroutine(Die());
            animator.SetTrigger("die");
        } 

    }

    public void InflictDamage(Transform attackpoint, float attackRange, LayerMask enemyLayer, int damage)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<NPC>().TakeDamage(damage);
            //UnityEngine.Debug.Log("Spin hit");
        }
    }


    protected void run(float horInput, float verInput)
    {
        rb.velocity = new Vector3(horInput, 0, verInput).normalized * speed;
        //Debug.Log(new Vector3(horInput, 0, verInput).normalized * speed);
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

    public IEnumerator Die()
    {
        Debug.Log(gameObject.name);
        Debug.Log(character.name);
        animator.SetTrigger("die");
        Debug.Log("Player DEAD");
        SceneManager.LoadScene("LoseMenu");
        yield return null;

    }

}
