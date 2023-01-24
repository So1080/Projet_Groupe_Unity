﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class ActionEnemy : NPC
{
    //[SerializeField] private GameObject player;
    //[SerializeField] private NavMeshAgent agent;
    //[SerializeField] private Animator animator;
    //public float visionRange;
    //public GameObject player;

    //attack
    public Transform attackPoint;
    public float attackRange = 1;

    
    void Start()
    {
        maxHealth = 20;
        health = maxHealth;
        
    }
    
    void Update()
    {
        FollowPlayer();


        if ((health > 0) && ((transform.position - player.transform.position).magnitude <= agent.stoppingDistance))
        {
            AttackSword();
        }
    }
    void AttackSword()
    {

        if (coolDown(lastHit, cooldown)) return; 
        //UnityEngine.Debug.Log("ATTACK");
        animator.SetTrigger("soldier");

        InflictDamage(attackPoint, attackRange, enemyLayer, hitPoints);
        lastHit = Time.time;

    }

    public void PushBack()
    {
        StartCoroutine(PushBackCo());
    }

    IEnumerator PushBackCo()
    {
        //Debug.Log("WAIT A SECOND");
        yield return new WaitForSeconds(1);
        transform.Translate(UnityEngine.Vector3.forward * speed * Time.deltaTime);
        //Debug.Log("PUSH");

        //Debug.Log("current health: " + health);
        yield return null;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}