using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float speed = 3;
    public int damage;
    public float torque;
    public Rigidbody​ rb;
    public LayerMask enemy;
    public bool didHit;
    private string enemyTag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetEnemyTag()
    {
        this.enemyTag = enemyTag;
    }

    public void fly(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    void onTriggerEnter(Collider collider)
    {
        if (didHit) return;
        didHit = true;

        if (collider.CompareTag("Player"))
        {

            GetComponent<Player>().TakeDamage(damage);

            Destroy(this.gameObject);
        }

    }
   
}
