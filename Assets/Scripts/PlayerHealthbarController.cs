using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbarController : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public Vector3 position;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            position = cam.GetComponent<Camera>().WorldToScreenPoint(player.transform.position);

            position.y += 50;
            transform.position = position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
