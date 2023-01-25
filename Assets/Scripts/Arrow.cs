using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : MonoBehaviour
{

    public LayerMask playerLayer;
    public int hitPoint;
    public GameObject arrowPrefab;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        //Physics.IgnoreLayerCollision(arrowLayer, enemyLayer);
        hitPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collide)
    {
        Debug.Log("COLLIIISSSIIIOONN!!!!!!!!!!!!!");
        // check if the arrow has hit a target
        int player = playerLayer.value;
        int collided = (int)Math.Pow(2,collide.gameObject.layer);
        int enemy = enemyLayer.value;
        Debug.Log("PLAYER " + player);
        Debug.Log("IDK WHAT IS COMING OUT " + collided);
        Debug.Log("ENEMY " + enemy);
        if (collided == enemy)
        {
            // do something when the arrow hits a target
            Debug.Log("Arrow hit PLAYER!");
            if (enemyLayer.value == 512) // l'enemie est le player
            {
                collide.GetComponent<Player>().TakeDamage(hitPoint);
            }else
            {
                collide.GetComponent<NPC>().TakeDamage(hitPoint);
            }
            Destroy(arrowPrefab);
        }
        else if (collided == player)
        {
            Debug.Log("We did not hit enemy");
            return;
        }
        Debug.Log("We HIT WALL");
        Destroy(arrowPrefab);
        
    }

}
