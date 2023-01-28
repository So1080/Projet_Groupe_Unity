using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayer : Player
{
    public GameObject arrowPrefab; // drag the arrow prefab in the inspector 
    public Transform arrowSpawnPoint; // drag the spawn point in the inspector
    public Transform arrowSpawnPoint2; // drag the spawn point in the inspector
    public Transform arrowSpawnPoint3; // drag the spawn point in the inspector 
    public float speedArrow;
    public float stoppingDistance = 100;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 50;
        health = maxHealth;
        coolDownHit1 = 1;
        coolDownHit2 = 5;
        coolDownHit3 = 5;
        damageHit1 = 5;
        damageHit2 = 2;
        damageHit3 = 10;
    }


    public override void Attack1()
    {

        if (coolDown(lastHit1, coolDownHit1)) return;
        StartCoroutine(ShootArrow());

        lastHit1 = Time.time;

    }

    public override void Attack2()
    {

        if (coolDown(lastHit2, coolDownHit2)) return;
        StartCoroutine(Shoot3Arrows());

        lastHit2 = Time.time;
    }

    public override void Attack3()
    {

        if (coolDown(lastHit3, coolDownHit3)) return;
        StartCoroutine(Improve());

        lastHit3 = Time.time;
    }

    IEnumerator ShootArrow()
    {
        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("ShootArrow");
        // instantiate the arrow prefab at the spawn point and give it an initial velocity
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        Debug.Log(rb);
        rb.velocity = arrow.transform.forward * speedArrow;
        yield return null;
    }

    IEnumerator Shoot3Arrows()
    {
        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(0.5f);
        GameObject arrow1 = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        GameObject arrow2 = Instantiate(arrowPrefab, arrowSpawnPoint2.position, arrowSpawnPoint2.rotation);
        GameObject arrow3 = Instantiate(arrowPrefab, arrowSpawnPoint3.position, arrowSpawnPoint3.rotation);
        Rigidbody rb1 = arrow1.GetComponent<Rigidbody>();
        rb1.velocity = arrow1.transform.forward * speedArrow;
        Rigidbody rb2 = arrow2.GetComponent<Rigidbody>();
        rb2.velocity = arrow2.transform.forward * speedArrow;
        Rigidbody rb3 = arrow3.GetComponent<Rigidbody>();
        rb3.velocity = arrow3.transform.forward * speedArrow;

    }

    IEnumerator Improve()
    {
        int initSpeed = speed;
        int initCoolDownHit = coolDownHit1;
        speed *= 2;
        coolDownHit1 = coolDownHit1 / 2;
        yield return new WaitForSeconds(3);
        speed = initSpeed;
        yield return new WaitForSeconds(7);
        coolDownHit1 = initCoolDownHit;
        yield return null;
    }
}
