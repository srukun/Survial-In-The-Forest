using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public float mainTimeCounter;
    public float earlyWarningTimer;
    public float waveSpawnTimer;



    public GameObject earlyWarningText;
    public GameObject mainTimeText;
    public bool isPaused;
    public bool combatStarted;
    void Start()
    {
        mainTimeCounter = -1f;
        

        LayerCollisionManagement();
    }


    void Update()
    {
        earlyWarningManagement();
        mainTimeCountManagement();
        WaveSpawnManagement();
    }
    public void LayerCollisionManagement()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
        Physics2D.IgnoreLayerCollision(6, 8);
        Physics2D.IgnoreLayerCollision(7, 9);
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(9, 9);
    }
    public void earlyWarningManagement()
    {
        if(earlyWarningTimer > 0)
        {
            earlyWarningTimer -= Time.deltaTime;
        }

        if (earlyWarningTimer <= 0 && earlyWarningText.activeInHierarchy)
        {
            earlyWarningText.SetActive(false);
        }
    }

    public void mainTimeCountManagement()
    {
        mainTimeCounter += Time.deltaTime;
        if (mainTimeCounter > 0)
        {
            int minutes = (int)(mainTimeCounter / 60);

            int seconds = (int)(mainTimeCounter % 60);

            if (minutes < 10 && seconds < 10)
            {
                mainTimeText.GetComponent<TextMeshProUGUI>().SetText("0" + minutes + ":" + "0" + seconds);
            }
            else if (minutes < 10 && seconds > 10)
            {
                mainTimeText.GetComponent<TextMeshProUGUI>().SetText("0" + minutes + ":" + seconds);
            }
            else if (minutes >= 10 && seconds < 10)
            {
                mainTimeText.GetComponent<TextMeshProUGUI>().SetText(minutes + ":" + "0" + seconds);
            }
            else
            {
                mainTimeText.GetComponent<TextMeshProUGUI>().SetText(minutes + ":" + seconds);
            }
        }
        if(mainTimeCounter > 0 && !combatStarted)
        {
            mainTimeText.SetActive(true);
            combatStarted = true;
        }
    }
    public void WaveSpawnManagement()
    {
        if (combatStarted)
        {
            if (waveSpawnTimer > 0)
            {
                waveSpawnTimer -= Time.deltaTime;
            }
            if (waveSpawnTimer <= 0)
            {
                waveSpawnTimer = 30f;
                SpawnWave();
                earlyWarningTimer = 4;
                earlyWarningText.SetActive(true);
                earlyWarningText.GetComponentInChildren<EarlyWarningTextManager>().timer = 0f;
                earlyWarningText.GetComponentInChildren<EarlyWarningTextManager>().text = "";

            }
        }

    }
    public void SpawnWave()
    {

    }



}
