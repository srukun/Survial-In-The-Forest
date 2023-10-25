using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static PlayerClass thisPlayer;
    public static int totalMoney;
    public static int playerLevel;
    public static float maxTime;
    public static float numEnemiesKilled;
    public static float shotsFired;
    public static WeaponClass equipedWeapon;
    public static int firstTimePlaying;
    private void Start()
    {
        if (thisPlayer == null)
        {
            DataManager.thisPlayer = new PlayerClass();
        }
        if (thisPlayer.weapons == null)
        {
            thisPlayer.weapons = new List<WeaponClass>();

            WeaponClass pistol = new WeaponClass("Pistol", 6.5f, 6f, 3, 16f, 0, true, "Weapons/Pistol");
            WeaponClass shotgun = new WeaponClass("Shotgun", 5f, 2.5f, 3.5f, 9f, 200, false, "Weapons/Shotgun");
            WeaponClass rifle = new WeaponClass("Rifle", 6f, 4.5f, 5, 13f, 400, false, "Weapons/Rifle");

            WeaponClass bow = new WeaponClass("Bow", 4f, 8f, 4, 10f, 200, false, "Weapons/Bow");
            WeaponClass longbow = new WeaponClass("Long Bow", 3f, 10f, 4, 8f, 350, false, "Weapons/Longbow");
            WeaponClass crossbow = new WeaponClass("Crossbow", 5f, 7f, 4, 9f, 500, false, "Weapons/Crossbow");

            thisPlayer.weapons.Add(pistol);
            thisPlayer.weapons.Add(shotgun);
            thisPlayer.weapons.Add(rifle);

            thisPlayer.weapons.Add(bow);
            thisPlayer.weapons.Add(longbow);
            thisPlayer.weapons.Add(crossbow);

            equipedWeapon = thisPlayer.weapons[0];
            totalMoney += 100;
        }
    }

}
