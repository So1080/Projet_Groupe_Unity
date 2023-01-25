using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : NPC
{
    public GameObject arrowPrefab; // drag the arrow prefab in the inspector 
    public Transform arrowSpawnPoint; // drag the spawn point in the inspector 
    public float fireRate = 4.0f; // time in seconds between arrow shots
    public float nextFire;
    public float speedArrow;
    public float stoppingDistance=100;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;
        maxHealth = health;
    }

    // Update is called once per frame
    

    public override void Attack()
    {
        if (Time.time > nextFire) // check if enough time has passed since the last shot
        {
            nextFire = Time.time + fireRate; // set the time for the next arrow shot
            StartCoroutine(ShootArrow()); // call the function to shoot an arrow
        }
    }


    IEnumerator ShootArrow()
    {

        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("ShootArrow");
        // instantiate the arrow prefab at the spawn point and give it an initial velocity
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
          Debug.Log(rb);
        rb.velocity = arrow.transform.forward * speedArrow;
        yield return null;
    }

    
}
