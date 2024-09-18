using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMove : MonoBehaviour
{
    private SpriteRenderer rabbitSR;

    Vector2 pos;
    [SerializeField]
    float maxMoving = 2.0f;
    [SerializeField]
    float speed = 3.0f;
    float flippp;
    bool isFlip = false;
    void Start()
    {
        rabbitSR = GetComponent<SpriteRenderer>();
        pos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        MovingRabbit();
    }
    void MovingRabbit()
    {
        Vector2 v = pos;
        flippp = maxMoving * Mathf.Sin(Time.time * speed);
        v.x += flippp;
        transform.position = v;

        if(flippp>0) 
        {
            isFlip = false;
        }
        else
        {
            isFlip = true;
        }
        rabbitSR.flipX = isFlip;
    }
}
