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
        moneyRewarded = 15 + 3 * level;
        if(level >= 1)
        {
            speed = 1.8f;
        }
        if(level > 3)
        {
            speed = 2f;
        }
        if (level > 6)
        {
            speed = 2.5f;
        }
        damage = 2 + 1.75f * level;
        if(level >= 1)
        {
            range = 6f;
        }
        if (level >= 3)
        {
            range = 7.33f;
        }
        if (level >= 6)
        {
            range = 8f;
        }
        //firerate
        if (level >= 1)
        {
            fireRate = 3;
        }
        if (level >= 2)
        {
            fireRate = 5;
        }
        if (level >= 7)
        {
            fireRate = 7;
        }
    }
}
    

