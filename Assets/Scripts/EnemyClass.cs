using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class EnemyClass
{
    public String name;
    public float maxHealth;
    public float health;
    public float experienceRewarded;
    public int moneyRewarded;
    public float speed;
    public float damage;
    public float range;
    public int fireRate;
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void AssignLevel(int level)
    {
        maxHealth = 10 + 4 * level;
        health = maxHealth;
        moneyRewarded = 1 + 2 * level;
        if(level >= 1)
        {
            speed = 2;
        }
        if(level > 3)
        {
            speed = 2.3f;
        }
        if (level > 6)
        {
            speed = 2.6f;
        }
        damage = 3 + .5f * level;
        if(level >= 1)
        {
            range = 4;
        }
        if (level >= 3)
        {
            range = 5;
        }
        if (level >= 6)
        {
            range = 5.5f;
        }
        //firerate
        if (level >= 1)
        {
            fireRate = 1;
        }
        if (level >= 2)
        {
            range = 2;
        }
        if (level >= 5)
        {
            range = 3;
        }
    }
}
    

