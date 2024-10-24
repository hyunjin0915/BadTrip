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

    protected Vector2 currentPosition;	//현재 위치(x)를 저장할 변수.
    protected float currentScaleX;		//현재 스케일(x)를 저장할 변수.
    protected float currentScaleY;

    protected float direction = 1.0f;	//방향.
    [SerializeField]
    protected float velocity;	//속도.

    void Start()
    {
        
    }

    void Update()
    {
        //Move();
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
}
