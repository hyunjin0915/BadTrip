using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMove : MonoBehaviour
{
    [SerializeField]
     private float rightMax = 5f;	//좌로 이동가능한 최대값.
     [SerializeField]
    private float leftMax = -5f;	//우로 이동가능한 최대값.
    private float rightMax_Apply;
    private float leftMax_Apply;

    private Vector2 currentPosition;	//현재 위치(x)를 저장할 변수.
    private float currentScaleX;		//현재 스케일(x)를 저장할 변수.
    private float currentScaleY;

    private float direction = 1.0f;	//방향.
    [SerializeField]
    private float velocity = 2.0f;	//속도.

    [SerializeField]
    private Rigidbody2D target;
    private Rigidbody2D rb;
    [SerializeField]
    float speed = 3.0f;

    public bool isFollow = false;

    [SerializeField]
    float FindRange = 4f; 
    void Start()
    {
        currentPosition = transform.position; //현재 위치의 x값 저장.
        currentScaleX = transform.localScale.x;	//현재 스케일의 x값 저장.
        currentScaleY = transform.localScale.y;	//현재 스케일의 x값 저장.

        rightMax_Apply = currentPosition.x+rightMax;
        leftMax_Apply = currentPosition.x + leftMax;

        //pos = transform.position;
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
    void FollowingPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, FindRange,LayerMask.GetMask("Player"));
        if(playerCollider!=null)
        {
            if(transform.position.x >= playerCollider.transform.position.x) LeftTurn();
            if(transform.position.x < playerCollider.transform.position.x) RightTurn();

            isFollow = true;
            Vector2 directionToPlayer = (target.position - rb.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x * speed, rb.velocity.y);
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }

    void Move()
    {
        //Vector2 v = pos;
        currentPosition = transform.position; 
        currentPosition.x += Time.deltaTime * direction * velocity;

        if (currentPosition.x >= rightMax_Apply)		//현재 위치가 rightMax보다 크거나 같다면
        {
            currentPosition.x = rightMax_Apply;			//현재 위치는 rightMax로 설정하고
            LeftTurn();					//LeftTurn을 실행한다.
        }

        else if (currentPosition.x <= leftMax_Apply)		//현재 위치가 leftMax보다 크거나 같다면
        {
            currentPosition.x = leftMax_Apply;			//현재 위치는 leftMax로 설정하고
            RightTurn();				//RightTurn을 실행한다.
        }
        transform.position = currentPosition;
        //transform.position = new Vector2(currentPosition.x, currentPosition.y);
    }

    private void LeftTurn()
    {
        direction = -1f;				//방향을 왼쪽으로 설정
        //currentScaleX에 -1을 곱한 값과 currentScaleY로 새로운 벡터를 생성해 localScale에 할당..
        transform.localScale = new Vector2(currentScaleX * -1, currentScaleY);
    }

    private void RightTurn()
    {
        direction = 1f;					//방향을 오른쪽으로 설정(원래 방향과 동일).
        transform.localScale = new Vector2(currentScaleX, currentScaleY);
    }

}