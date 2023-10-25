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
    public float speed;
    public int cost;
    public bool isBought;
    public string sprite;
    public WeaponClass(String name, float damage, float range, float fireRate, int cost, bool isBought)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
        this.fireRate = fireRate;
        this.cost = cost;
        this.isBought = isBought;
    }
    public WeaponClass(String name, float damage, float range, float fireRate, float speed, int cost, bool isBought, string sprite)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
        this.fireRate = fireRate;
        this.speed = speed;
        this.cost = cost;
        this.isBought = isBought;
        this.sprite = sprite;
    }
    public bool equals(WeaponClass weapon)
    {
        if(this.name == weapon.name)
        {
            return true;
        }
        return false;
    }

}
