using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mollusk : MovingMon
{
    [SerializeField]
    private Rigidbody2D target;
    private Rigidbody2D rb;
    [SerializeField]
    float FollowingSpeed = 3.0f;
    public bool isFollow = false;

    [SerializeField]
    float FindRange = 4f; 

    public Animator animator;
     protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
    }
   void Update()
   {
        if(!isFollow)
        {
            Move();
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
            animator.SetTrigger("Attack");
        }
        else
        {
            if(isFollow)
            {
                isFollow = false;
                rightMax_Apply = transform.position.x + rightMax;
                leftMax_Apply = transform.position.x + leftMax;
            }
            animator.SetTrigger("StopAttack");
            rb.velocity = Vector2.zero;
        }
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }

}
