using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class EnemyController : MonoBehaviour
{
    public EnemyClass thisEnemy;
    public GameObject player;
    public GameObject enemyProjectilePrefab;
    public float shootTimer;
    public GameObject healthbar;
    public GameObject healthbarPrefab;
    public bool playerInRange;
    void Start()
    {
        healthbar = Instantiate(healthbarPrefab, transform.position, Quaternion.identity);
        healthbar.GetComponent<EnemyHealthbarController>().enemy = gameObject;
        healthbar.transform.SetParent(GameObject.Find("Canvas").transform);
        UpdateHealthbar();
        shootTimer = 1f;   
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > 1.5f && playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, thisEnemy.speed * Time.deltaTime);
        }
        Shoot();
    }

    public void Shoot()
    {
        if(!playerInRange && Vector2.Distance(transform.position, player.transform.position) < 5f)
        {
            healthbar.SetActive(true);
            playerInRange = true;
        }
        else if(playerInRange && Vector2.Distance(transform.position, player.transform.position) > 5f)
        {
            healthbar.SetActive(false);
            playerInRange = false;
        }
        if (shootTimer <= 0 && playerInRange)
        {
            GameObject enemyProjectile = Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity);
            
            Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
            Vector3 offset = transform.position + direction * (thisEnemy.range + 2);

            enemyProjectile.GetComponent<EnemyProjectileScript>().thisEnemy = thisEnemy;
            enemyProjectile.GetComponent<EnemyProjectileScript>().endPos = offset;
            enemyProjectile.GetComponent<EnemyProjectileScript>().range = thisEnemy.range;
            
            shootTimer = 1f/thisEnemy.fireRate;
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }


    }
    public void UpdateHealthbar()
    {
        healthbar.GetComponent<Slider>().maxValue = thisEnemy.maxHealth;
        healthbar.GetComponent<Slider>().value = thisEnemy.health;
    }

}
