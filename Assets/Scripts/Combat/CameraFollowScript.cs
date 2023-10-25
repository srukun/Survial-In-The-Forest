using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float damping;
    // Update is called once per frame
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        offset.z = -16;
        Vector3 movePos = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePos, ref velocity, damping);
    }
}