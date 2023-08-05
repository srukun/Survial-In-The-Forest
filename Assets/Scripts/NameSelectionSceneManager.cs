using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NameSelectionSceneManager : MonoBehaviour
{
    public GameObject inputField;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectName();
        }
    }
    public void SelectName()
    {
        DataManager.thisPlayer = new PlayerClass();
        WeaponClass pistol = new WeaponClass("Pistol", 6.5f, 6f, 3, 0, true);
        WeaponClass shotgun = new WeaponClass("Shotgun", 5f, 2.5f, 3, 200, false);
        WeaponClass rifle = new WeaponClass("Rifle", 6f, 4.5f, 5, 400, false);

        WeaponClass bow = new WeaponClass("Bow", 4f, 8f, 4, 200, false);
        WeaponClass longbow = new WeaponClass("Long Bow", 3f, 10f, 4, 350, false);
        WeaponClass crossbow = new WeaponClass("Crossbow", 5f, 7f, 4, 500, false);

        DataManager.thisPlayer.weapons = new List<WeaponClass>();
        DataManager.thisPlayer.weapons.Add(pistol);
        DataManager.thisPlayer.weapons.Add(shotgun);
        DataManager.thisPlayer.weapons.Add(rifle);

        DataManager.thisPlayer.weapons.Add(bow);
        DataManager.thisPlayer.weapons.Add(longbow);
        DataManager.thisPlayer.weapons.Add(crossbow);

        DataManager.equipedWeapon = DataManager.thisPlayer.weapons[0];
        DataManager.totalMoney += 100;
        string name = inputField.GetComponentInChildren<TMP_InputField>().text;
        if(name.Length < 1)
        {
            name = "John Doe";
        }
        DataManager.thisPlayer.name = name;
        SceneManager.LoadScene(0);
    }
}
