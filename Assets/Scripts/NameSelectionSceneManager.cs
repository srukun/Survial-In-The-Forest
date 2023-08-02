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
        WeaponClass bow = new WeaponClass();
        bow.name = "Pistol";
        bow.type = "Pistol";
        bow.range = 2.3f;
        bow.fireRate = 2;
        bow.damage = 7;
        DataManager.thisPlayer.weapons = new List<WeaponClass>();
        DataManager.thisPlayer.weapons.Add(bow);
        string name = inputField.GetComponentInChildren<TMP_InputField>().text;
        if(name.Length < 1)
        {
            name = "John Doe";
        }
        DataManager.thisPlayer.name = name;
        SceneManager.LoadScene(0);
    }
}
