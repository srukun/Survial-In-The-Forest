using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArenaManager : MonoBehaviour
{
    public bool isPaused;
    public float mainTimeCounter;
    public float earlyWarningTimer;
    public float waveSpawnTimer;



    public GameObject earlyWarningText;
    public GameObject mainTimeText;
    public bool combatStarted;
    public GameObject[] spawnPoints;
    public GameObject player;
    public GameObject slimePrefab;
    public int maxEnemySpawnable;
    public int totalCashEarned;
    public GameObject playerCashText;
    public int enemySpawnLevel;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public PlayerClass thisPlayer;
    void Start()
    {
        mainTimeCounter = -1f;
        enemySpawnLevel = 1;
        maxEnemySpawnable = 14;
        LayerCollisionManagement();
        thisPlayer = player.GetComponent<Controller>().thisPlayer;
        UpdatePlayerCash();
    }


    void Update()
    {
        if (!isPaused)
        {
            earlyWarningManagement();
            mainTimeCountManagement();
            WaveSpawnManagement();
        }
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
                if(maxEnemySpawnable < 16)
                {
                    maxEnemySpawnable++;
                }
                enemySpawnLevel++;
            }
        }

    }
    public void SpawnWave()
    {
        for (int i = 0; i < maxEnemySpawnable; i++)
        {
            GameObject enemy = Instantiate(slimePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyController>().player = player;
            enemy.GetComponent<EnemyController>().thisEnemy.AssignLevel(enemySpawnLevel);
            float waitTime = 0;

            if (i < maxEnemySpawnable*.33)
            {
                waitTime = Random.Range(1, 4);
            }
            else if( i >= maxEnemySpawnable*.33 && i < maxEnemySpawnable * .66)
            {
                waitTime = Random.Range(6, 12);
            }
            else if(i >= maxEnemySpawnable * .66)
            {
                waitTime = Random.Range(14, 21);
            }
            enemy.GetComponent<EnemyController>().waitTime = waitTime;

        }
    }
    public void UpdatePlayerCash()
    {
        playerCashText.GetComponent<TextMeshProUGUI>().SetText("$" + totalCashEarned);
    }
    public void PauseGame()
    {
        if (!isPaused && player.GetComponent<Controller>().thisPlayer.health > 0)
        {
            isPaused = true;
            pauseScreen.SetActive(true);
        }
    }
    public void Unpause()
    {
        if (isPaused && player.GetComponent<Controller>().thisPlayer.health > 0)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
        }
    }
    public void DisplayDeathScreen()
    {

        isPaused = true;
        deathScreen.SetActive(true);
        pauseScreen.SetActive(false);

    }
}
