using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpawnManager : MonoBehaviour
{
    public GameObject player;
    private Vector2 playerPos;
    private Rigidbody2D leftHandRb;
    private Rigidbody2D rightHandRb;

    public GameObject Lefthand;
    public GameObject Righthand;
    public float handMoveSpeed = 5.0f;
    public float handAttackSpeed = 20f;

    [Tooltip("Get Hand Position delay time")]
    public float delayTime = 4f;

    [Tooltip("Hand attack delay time")]
    public float attackDelay =3f;

    Vector2 moveToPos;
    public Vector2 attackPos;
    bool isLeft;
    public bool isAttack;


    // Start is called before the first frame update
    void Start()
    {
        attackPos = Vector2.down;
        isAttack = false;
        leftHandRb = Lefthand.GetComponent<Rigidbody2D>();
        rightHandRb = Righthand.GetComponent<Rigidbody2D>();
        StartCoroutine("GetHandPos",delayTime);
        //StartCoroutine("AttackHands");
    }
    void FixedUpdate()
    {
        //if(Math.Abs(playerPos.x - leftHandRb.position.x) < 0.1f) isAttack = true;

        if(!isAttack && Math.Abs(playerPos.x - leftHandRb.position.x) >= 0.1f && Math.Abs(playerPos.x - rightHandRb.position.x) >= 0.1f)
        {
            if(leftHandRb != null && playerPos.x<=0)
            {
                isLeft = true;
                moveToPos = (playerPos.x-leftHandRb.position.x) > 0 ? Vector2.right : Vector2.left;
                leftHandRb.MovePosition(leftHandRb.position + moveToPos * handMoveSpeed * Time.fixedDeltaTime);
            }
            else if(rightHandRb != null && playerPos.x>0)
            {
                isLeft = false;
                moveToPos = (playerPos.x-rightHandRb.position.x) > 0 ? Vector2.right:Vector2.left;
                rightHandRb.MovePosition(rightHandRb.position + moveToPos.normalized * handMoveSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if(leftHandRb != null && playerPos.x<=0)
            {
                leftHandRb.MovePosition(leftHandRb.position + attackPos*handAttackSpeed*Time.fixedDeltaTime);
                if(leftHandRb.position.y<-10 || leftHandRb.position.y>25)
                {
                    attackPos.y = 1;
                }
                else if(leftHandRb.position.y == 25) 
                {
                    isAttack =  false;
                     attackPos.y = -1;
                }
            }
            else if(rightHandRb != null && playerPos.x>0)
            {
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

    private IEnumerator AttackHands()
    {
        isAttack = true;
        yield return new WaitForSeconds(attackDelay);     
        StartCoroutine("AttackHands");
   
    }

}