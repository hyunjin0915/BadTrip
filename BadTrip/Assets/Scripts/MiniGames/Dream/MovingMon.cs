using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMon : MonoBehaviour
{
    [SerializeField]
    protected float rightMax;	//좌로 이동가능한 최대값.
     [SerializeField]
    protected float leftMax;	//우로 이동가능한 최대값.
    protected float rightMax_Apply;
    protected float leftMax_Apply;

    [SerializeField]
    protected float upMax;
    [SerializeField]
    protected float downMax;
    protected float upMax_Apply;
    protected float downMax_Apply;

    float perDirection = 1.0f;

    protected Vector2 currentPosition;	//현재 위치(x)를 저장할 변수.
    protected float currentScaleX;		//현재 스케일(x)를 저장할 변수.
    protected float currentScaleY;

    protected float direction = 1.0f;	//방향.
    [SerializeField]
    protected float velocity;	//속도.
    [SerializeField]
    float FlyingSpeed;


    protected virtual void Start()
    {
        currentPosition = transform.position; //현재 위치의 x값 저장.
        currentScaleX = transform.localScale.x;	//현재 스케일의 x값 저장.
        currentScaleY = transform.localScale.y;	//현재 스케일의 x값 저장.
        
        rightMax_Apply = currentPosition.x+rightMax;
        leftMax_Apply = currentPosition.x + leftMax;

    }

    protected virtual void Move()
    {
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

    protected void LeftTurn()
    {
        direction = -1f;				//방향을 왼쪽으로 설정
        //currentScaleX에 -1을 곱한 값과 currentScaleY로 새로운 벡터를 생성해 localScale에 할당..
        transform.localScale = new Vector2(currentScaleX * -1, currentScaleY);
    }

    protected void RightTurn()
    {
        direction = 1f;					//방향을 오른쪽으로 설정(원래 방향과 동일).
        transform.localScale = new Vector2(currentScaleX, currentScaleY);
    }
    protected void Fly()
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
}
