using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager
{

    private int health;
    private int healthMax;

    public HealthManager(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int hitPoint)
    {
        health -= hitPoint;
        if (health < 0) health = 0;
    }

}
