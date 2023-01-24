using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrowPrefab; // drag the arrow prefab in the inspector 
    public Transform arrowSpawnPoint; // drag the spawn point in the inspector 
    public float fireRate = 2.0f; // time in seconds between arrow shots
    public float nextFire;
    public int hitPoint = 3;
    public float speedArrow;
    public Animator animator;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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
        Debug.Log("ShootArrow");
        // instantiate the arrow prefab at the spawn point and give it an initial velocity
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        Debug.Log(rb);
        rb.velocity = arrow.transform.forward * speedArrow;
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("idle");
        yield return null;
    }

    void OnTriggerEnter(Collision collision)
    {
        Debug.Log("COLLIIISSSIIIOONN!!!!!!!!!!!!!");
        // check if the arrow has hit a target
        if (collision.gameObject.layer == playerLayer)
        {
            // do something when the arrow hits a target
            Debug.Log("Arrow hit a target!");
            GetComponent<Player>().TakeDamage(hitPoint);
            Destroy(arrowPrefab);
        }
    }
}
