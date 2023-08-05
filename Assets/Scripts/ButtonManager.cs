using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadArena()
    {
        if(DataManager.firstTimePlaying != 1) 
        {
            DataManager.firstTimePlaying = 1;
            SceneManager.LoadScene(6);
        }
        else if (DataManager.firstTimePlaying == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadUpgrade()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadStatistics()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(7);
    }
}
