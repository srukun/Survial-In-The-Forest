using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerClass
{
    public String name;
    public float maxHealth;
    public float health;
    public float maxExperience;
    public float experience;
    public float speed;
    public List<WeaponClass> weapons;
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
