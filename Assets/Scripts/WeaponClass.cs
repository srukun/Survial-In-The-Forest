using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class WeaponClass 
{
    public String name;
    public float damage;
    public float range;
    public float fireRate;
    public int cost;
    public bool isBought;
    public WeaponClass(String name, float damage, float range, float fireRate, int cost, bool isBought)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
        this.fireRate = fireRate;
        this.cost = cost;
        this.isBought = isBought;
    }

}
