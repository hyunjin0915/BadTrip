using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Lefthand;
    public GameObject Righthand;

    private Rigidbody2D leftHandRb;
    private Rigidbody2D rightHandRb;

    public float handMoveSpeed = 5.0f;
    public float handAttackSpeed = 20f;

    [Tooltip("Get Hand Position delay time")]
    public float delayTime = 4f;
    private float LHandAbs;
    private float RHandAbs;

    private Vector2 playerPos;
    private Vector2 moveToPos;
    private Vector2 LattackPos;
    private Vector2 RattackPos;
    public bool isLAttack;
    public bool isRAttack;

    // Start is called before the first frame update
    void Start()
    {
        LattackPos = Vector2.down;
        RattackPos = Vector2.down;

        isLAttack = false;
        isRAttack = false;

        leftHandRb = Lefthand.GetComponent<Rigidbody2D>();
        rightHandRb = Righthand.GetComponent<Rigidbody2D>();

        StartCoroutine("GetHandPos",delayTime);
    }
    void FixedUpdate()
    {
        LHandAbs = Math.Abs(playerPos.x - leftHandRb.position.x);
        RHandAbs = Math.Abs(playerPos.x - rightHandRb.position.x);

        if(LHandAbs < 1f) isLAttack = true;
        if(RHandAbs < 1f) isRAttack = true;

        if(!isLAttack && !isRAttack && LHandAbs >= 1f && RHandAbs >= 1f)
        {
            if(leftHandRb != null && playerPos.x<=0)
            {
                moveToPos = (playerPos.x-leftHandRb.position.x) > 0 ? Vector2.right : Vector2.left;
                leftHandRb.MovePosition(leftHandRb.position + moveToPos * handMoveSpeed * Time.fixedDeltaTime);
            }
            else if(rightHandRb != null && playerPos.x>0)
            {
                moveToPos = (playerPos.x-rightHandRb.position.x) > 0 ? Vector2.right:Vector2.left;
                rightHandRb.MovePosition(rightHandRb.position + moveToPos.normalized * handMoveSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if(leftHandRb != null && playerPos.x<=0) //플레이어가 왼쪽에 있을 때
            {
                if(isRAttack)
                {
                    AttackRHand();
                }
                AttackLHand();
            }
            else if(rightHandRb != null && playerPos.x>0) //플레이어가 오른쪽에 있을 때
            {
                if(isLAttack)
                {
                    AttackLHand();
                }
                AttackRHand();
            }
        }
    }

    private IEnumerator GetHandPos(float delayTime)
    {
        playerPos = player.transform.position;
        yield return new WaitForSeconds(delayTime);
        //StartCoroutine("AttackHands", attackDelay);
        StartCoroutine("GetHandPos", delayTime);
    }

    private void AttackRHand()
    {
        rightHandRb.MovePosition(rightHandRb.position + RattackPos*handAttackSpeed*Time.fixedDeltaTime);
        if(rightHandRb.position.y<=-10)
        {
            RattackPos.y = 1;
        }
        else if(rightHandRb.position.y > 25) 
        {
            isRAttack =  false;
            RattackPos.y = -1;
        }
    }
    private void AttackLHand()
    {
        leftHandRb.MovePosition(leftHandRb.position + LattackPos*handAttackSpeed*Time.fixedDeltaTime);

        if(leftHandRb.position.y<=-10)
        {
            LattackPos.y = 1;
        }
        else if(leftHandRb.position.y > 25) 
        {
            isLAttack =  false;
            LattackPos.y = -1;
        }
    }
}