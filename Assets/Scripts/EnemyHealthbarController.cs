using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealthbarController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject cam;
    public Vector3 position;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        transform.localScale= Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            position = cam.GetComponent<Camera>().WorldToScreenPoint(enemy.transform.position);
            position.y += 30;
            transform.position = position;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
