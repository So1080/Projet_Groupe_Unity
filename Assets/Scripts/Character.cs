using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character;
    public Animator animator;
    protected int maxHealth;
    protected int health;
    public LayerMask enemyLayer;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        //health = maxHealth;
    }
  


    public IEnumerator Die()
    {
        Debug.Log(gameObject.name);
        Debug.Log(character.name);
        animator.SetTrigger("die");
        Debug.Log("Enemy DEAD"); 
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        yield return null;

    }

    public bool coolDown(float last, int coolDown)
    {
        if (Time.time - last < coolDown && last != 0)
        {
            UnityEngine.Debug.Log("WAIT");
            return true;
        }
        return false;
    }
}
