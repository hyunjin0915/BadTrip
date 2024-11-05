using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MovingMon
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
     protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        upMax_Apply = currentPosition.y+upMax;
        downMax_Apply = currentPosition.y + downMax;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }
}
