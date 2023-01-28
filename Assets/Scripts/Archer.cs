using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : NPC
{
    public GameObject arrowPrefab; 
    public Transform arrowSpawnPoint; 
    public float fireRate = 4.0f; 
    public float nextFire;
    public float speedArrow;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        maxHealth = health;
        //Solyane
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    

    public override void Attack()
    {
        if (Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate; 
            StartCoroutine(ShootArrow()); 
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
