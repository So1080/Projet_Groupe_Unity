﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class AttackWarrior : Player
{
    public Transform attackpoint;

    public static explicit operator AttackWarrior(GameObject v)
    {
        throw new NotImplementedException();
    }

    public Transform blastpoint;
    public Transform spinpoint;
    public float attackRange = 1;
    public float jumpRange = 3;
    public float spinRange = 5;

    //health

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 80;
        health = maxHealth;
        coolDownHit1 = 1;
        coolDownHit2 = 5;
        coolDownHit3 = 5;
        damageHit1 = 5;
        damageHit2 = 2;
        damageHit3 = 10;
    }

    // Update is called once per frame

    public override void Attack1()
    {

        if (coolDown(lastHit1, coolDownHit1)) return;

        //UnityEngine.Debug.Log("ATTACK");
        animator.SetTrigger("Attack");

        InflictDamage(attackpoint, attackRange, enemyLayer, damageHit1);

        lastHit1 = Time.time;
    }

    public override void Attack2()
    {

        if (coolDown(lastHit2, coolDownHit2)) return;

        //UnityEngine.Debug.Log("JUMP");
        animator.SetTrigger("Jump");

        InflictDamage(attackpoint, attackRange, enemyLayer, damageHit2);

        Collider[] blastEnemies = Physics.OverlapSphere(blastpoint.position, jumpRange, enemyLayer);

        foreach (Collider enemy in blastEnemies)
        {
            UnityEngine.Debug.Log("Blast hit");
            enemy.GetComponent<NPC>().PushBack();


            //enemyAnimator.SetTrigger("hit");
        }

        lastHit2 = Time.time;
    }

    public override void Attack3()
    {
        if (coolDown(lastHit3, coolDownHit3)) return;
        
        animator.SetTrigger("spin");

        InflictDamage(spinpoint, spinRange, enemyLayer, damageHit3);

        lastHit3 = Time.time;
    }

    /*void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        { 
            return;
        }
        Gizmos.DrawSphere(attackpoint.position, attackRange);
    }*/

    /*void OnDrawGizmosSelected()
    {
        if (spinpoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(spinpoint.position, spinRange);
    }*/


}  
