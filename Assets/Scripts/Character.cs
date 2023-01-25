using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character;
    public Animator animator;
    [System.NonSerialized] public int maxHealth;
    [System.NonSerialized] public int health;
    public LayerMask enemyLayer;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        //health = maxHealth;
    }

    public bool isAlive()
    {
        if (this.health == 0)
        {
            return false;
        }
        return true;
    }
 

    public bool coolDown(float last, int coolDown)
    {
        if (Time.time - last < coolDown && last != 0)
        {
            //UnityEngine.Debug.Log("WAIT");
            return true;
        }
        return false;
    }
}
