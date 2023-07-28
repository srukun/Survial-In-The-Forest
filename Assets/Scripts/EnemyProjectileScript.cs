using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public EnemyClass thisEnemy;
    public float range;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Travel();
    }
    private void Travel()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, 12f * Time.deltaTime);
        if(Vector3.Distance(transform.position, startPos) >= range)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Controller>().thisPlayer.TakeDamage(thisEnemy.damage);
            collision.gameObject.GetComponent<Controller>().UpdateHealthAndExp();

            Destroy(gameObject);
        }
    }
}
