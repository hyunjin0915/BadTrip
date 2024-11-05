using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMonMove : MovingMon
{
    [SerializeField]
    private Rigidbody2D target;
    private Rigidbody2D rb;
    [SerializeField]
    float FollowingSpeed = 3.0f;
    protected override void  Start()
    {
        base.Start();
        
        rb = GetComponent<Rigidbody2D>();
        GameObject targetObj = GameObject.FindGameObjectWithTag("SOPlayer");
        target = targetObj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowingPlayer();
    }
    void FollowingPlayer()
    {
        if(transform.position.x >= target.transform.position.x) LeftTurn();
        if(transform.position.x < target.transform.position.x) RightTurn();

        Vector2 directionToPlayer = (target.position - rb.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x * FollowingSpeed, rb.velocity.y);
        
    }
    
}
