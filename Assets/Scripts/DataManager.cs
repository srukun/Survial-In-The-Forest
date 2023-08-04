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
    private void Start()
    {
        if(thisPlayer == null)
        {
            SceneManager.LoadScene(5);
        }
        totalMoney = 9999;
    }

}
