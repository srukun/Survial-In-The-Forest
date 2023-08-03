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
        
    }
    public void SelectName()
    {
        DataManager.thisPlayer = new PlayerClass();
        WeaponClass pistol = new WeaponClass("Pistol", 7f, 6f, 3, 0, true);
        WeaponClass shotgun = new WeaponClass("Shotgun", 5f, 2.5f, 3, 4000, false);
        WeaponClass rifle = new WeaponClass("Rifle", 6f, 5f, 5, 8000, false);

        DataManager.thisPlayer.weapons = new List<WeaponClass>();
        DataManager.thisPlayer.weapons.Add(pistol);
        DataManager.thisPlayer.weapons.Add(shotgun);
        DataManager.thisPlayer.weapons.Add(rifle);

        string name = inputField.GetComponentInChildren<TMP_InputField>().text;
        if(name.Length < 1)
        {
            name = "John Doe";
        }
        DataManager.thisPlayer.name = name;
        SceneManager.LoadScene(0);
    }
}
