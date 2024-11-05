using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugFly : MovingMon
{
    [SerializeField]
    private Rigidbody2D target;
    private Rigidbody2D rb;
    
    [SerializeField]
    float FlyingSpeed;
    public bool isFollow = false;

    [SerializeField]
    float FindRange = 4f; 

    [SerializeField]
    float FollowingSpeed = 3.0f;

    [SerializeField]
    private float upMax;
    [SerializeField]
    private float downMax;
    private float upMax_Apply;
    private float downMax_Apply;

    float perDirection = 1.0f;

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
        if(!isFollow)
        {
            Move();
            Fly();
        } 
        FollowingPlayer();
    }
    protected override void Move()
    {
        currentPosition = transform.position;
        base.Move();
    }
    
    void FollowingPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, FindRange,LayerMask.GetMask("Player"));
        if(playerCollider!=null)
        {
            if(transform.position.x >= playerCollider.transform.position.x) LeftTurn();
            if(transform.position.x < playerCollider.transform.position.x) RightTurn();

            isFollow = true;
            Vector2 directionToPlayer = (target.position - rb.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x * FollowingSpeed, rb.velocity.y);
        }
        else
        {
            if(isFollow)
            {
                isFollow = false;
                rightMax_Apply = transform.position.x + rightMax;
                leftMax_Apply = transform.position.x + leftMax;
            }
            rb.velocity = Vector2.zero;
        }
        
    }

    public void Fly()
    {
        currentPosition.y += Time.deltaTime * perDirection * FlyingSpeed;

        if(currentPosition.y >= upMax_Apply)
        {
            currentPosition.y = upMax_Apply;
            perDirection = -1f;
        }
        else if(currentPosition.y <= downMax_Apply)
        {
            currentPosition.y = downMax_Apply;
            perDirection = 1f;
        }
        transform.position = currentPosition;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }
}
