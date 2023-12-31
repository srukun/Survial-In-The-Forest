using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 startPos;
    public PlayerClass thisPlayer;
    public float range;
    public Rigidbody2D rb;
    public GameObject playerObject;
    void Start()
    {
        DataManager.shotsFired++;
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Travel();
    }
    public void Travel()
    {
        
        if (Vector3.Distance(transform.position, startPos) >= range)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyClass enemy = collision.gameObject.GetComponent<EnemyController>().thisEnemy;
            enemy.TakeDamage(thisPlayer.weapons[0].damage);
            collision.gameObject.GetComponent<EnemyController>().UpdateHealthbar();
            if(collision.gameObject.GetComponent<EnemyController>().thisEnemy.health <= 0)
            {
                playerObject.GetComponent<Controller>().RewardMoney(enemy.moneyRewarded);
                DataManager.numEnemiesKilled++;
                playerObject.GetComponent<Controller>().UpdateHealthAndExp();
                Destroy(collision.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
