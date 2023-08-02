using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatisticsScene : MonoBehaviour
{
    public GameObject statsText;
    void Start()
    {
        statsText.GetComponent<TextMeshProUGUI>().SetText("Name: \t\t\t\t\t\"" + 
            DataManager.thisPlayer.name +"\"\r\nLevel: \t\t\t\t"+ DataManager.thisPlayer.level + 
            "\r\nMoney: \t\t\t\t" + "$" + DataManager.totalMoney + "\r\nLongest Time: \t\t\t" + 
            DataManager.maxTime +"\r\nTotal Enemies Killed: \t\t"+ DataManager.numEnemiesKilled +
            "\r\n" + "Total Shots Fired" + "\t\t\t"+ DataManager.shotsFired);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
