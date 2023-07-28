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
    public float speed;
    public float damage;
    public float range;
    public int fireRate;
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
    

