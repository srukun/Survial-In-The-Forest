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
        SceneManager.LoadScene(1);
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
}
