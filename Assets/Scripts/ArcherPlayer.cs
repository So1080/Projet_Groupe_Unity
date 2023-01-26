using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayer : Player
{
    public GameObject arrowPrefab; // drag the arrow prefab in the inspector 
    public Transform arrowSpawnPoint; // drag the spawn point in the inspector 
    public float speedArrow;
    public float stoppingDistance = 100;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        coolDownHit1 = 1;
        coolDownHit2 = 5;
        coolDownHit3 = 5;
        damageHit1 = 5;
        damageHit2 = 2;
        damageHit3 = 10;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) Attack1();

        }

    }*/

    public override void Attack1()
    {

        if (coolDown(lastHit1, coolDownHit1)) return;
        StartCoroutine(ShootArrow());
        
    }

    public override void Attack2()
    {

    }

    public override void Attack3()
    {

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
}
