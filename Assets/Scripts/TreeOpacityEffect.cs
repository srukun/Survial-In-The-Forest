using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOpacityEffect : MonoBehaviour
{
    public Transform playerTransform;
    public float distance;
    public float alphaValue;
    public Color color;

    void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, playerTransform.position);

        if(distance < 6f && alphaValue != .25f)
        {
            alphaValue = .25f;
            GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, alphaValue);
        }
        else if(distance >= 6f && alphaValue != 1f)
        {
            alphaValue = 1f;
            GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, alphaValue);
        }
    }
}
