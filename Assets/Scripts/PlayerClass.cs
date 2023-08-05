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
    public int level;

    public float speed;
    public float damage;
    public int levelUpCost;
    public List<WeaponClass> weapons;
    public PlayerClass() {
        maxHealth = 30;
        level = 1;
        speed = 6;
        damage = 4;
        levelUpCost = 50;
    
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void LevelUp()
    {
        maxHealth += 5;
        level++;
        if(level == 5)
        {
            speed++;
        }
        damage += 2;
        levelUpCost *= 2;
    }
    public float GetDamage()
    {
        return damage + DataManager.equipedWeapon.damage;
    }
}
