using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSceneManager : MonoBehaviour
{
    public GameObject levelUpButton;
    public GameObject currentLevelInformation;
    public GameObject nextLevelInformation;
    void Start()
    {
        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        if(DataManager.thisPlayer.levelUpCost < DataManager.totalMoney)
        {
            DataManager.thisPlayer.LevelUp();
            UpdateTexts();
        }
    }
    public void UpdateTexts()
    {
        currentLevelInformation.GetComponent<TextMeshProUGUI>().SetText(DataManager.thisPlayer.level+"\r\n" +
            DataManager.thisPlayer.maxHealth+"\r\n" +
            DataManager.thisPlayer.speed+"\r\n" +
            DataManager.thisPlayer.damage);
        if(DataManager.thisPlayer.level != 4)
        {
            nextLevelInformation.GetComponent<TextMeshProUGUI>().SetText((DataManager.thisPlayer.level + 1) +
            "\r\n" +
            (DataManager.thisPlayer.maxHealth + 5) +
            "\r\n" +
            DataManager.thisPlayer.speed +
            "\r\n" +
            (DataManager.thisPlayer.damage + 2) +
            "\r\n");
        }
        else if(DataManager.thisPlayer.level == 4){
            nextLevelInformation.GetComponent<TextMeshProUGUI>().SetText((DataManager.thisPlayer.level + 1) +
                "\r\n" +
                (DataManager.thisPlayer.maxHealth + 5) +
                "\r\n" +
                "7" +
                "\r\n" +
                (DataManager.thisPlayer.damage + 2) +
                "\r\n");
        }
        levelUpButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Level Up $" + DataManager.thisPlayer.levelUpCost);
    }
}
