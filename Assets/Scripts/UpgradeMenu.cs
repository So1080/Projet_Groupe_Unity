using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{

    [SerializeField] private AttackWarrior player;



    //augmenter la vitesse du joueur
    public void Upgrade1()
    {
        Debug.Log("upgrade1 selected");
        player.speed += 1;
    }


    //réduire cooldown attaque 1
    public void Upgrade2()
    {
        Debug.Log("upgrade2 selected");
        if (player.coolDownHit1 > 0)
        {
            player.coolDownHit1 -= 1;
        }

    }

    //réduire cooldown attaque 2
    public void Upgrade3()
    {
        Debug.Log("upgrade3 selected");
        if (player.coolDownHit1 > 0)
        {
            player.coolDownHit1 -= 1;
        }
    }

    //réduire cooldown attaque 3
    public void Upgrade4()
    {
        Debug.Log("upgrade4 selected");
        if (player.coolDownHit1 > 0)
        {
            player.coolDownHit1 -= 1;
        }
    }

    //gain pdv
    public void Upgrade5()
    {
        Debug.Log("upgrade5 selected");
        player.health = player.maxHealth;
    }

    //Invincible pendant 3 secondes
    public void Upgrade6()
    {
        Debug.Log("upgrade6 selected");
        if (player.tookDamage)
        {
            player.health += player.damages;
        }
    }

    //tous les ennemis proches ont -5pv
    public void Upgrade7()
    {
        Debug.Log("upgrade7 selected");

        player.InflictDamage(player.attackpoint, player.attackRange, player.enemyLayer, 5);

    }

    //+1 point de dégâts pour l’attaque 1
    public void Upgrade8()
    {
        Debug.Log("upgrade8 selected");
        player.damageHit1 += 1;
    }

    //+1 point de dégâts pour l’attaque 2
    public void Upgrade9()
    {
        Debug.Log("upgrade9 selected");
        player.damageHit2 += 1;
    }

    //+1 point de dégâts pour l’attaque 3
    public void Upgrade10()
    {
        Debug.Log("upgrade10 selected");
        player.damageHit3 += 1;
    }
}
