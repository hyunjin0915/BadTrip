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
    public float attackDelay =10f;

    Vector2 moveToPos;
    public Vector2 attackPos = Vector2.down;
    bool isLeft;
    bool isAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        leftHandRb = Lefthand.GetComponent<Rigidbody2D>();
        rightHandRb = Righthand.GetComponent<Rigidbody2D>();
        StartCoroutine("GetHandPos",delayTime);

    }
    void FixedUpdate()
    {
        if(!isAttack)
        {
            if(leftHandRb != null && playerPos.x<=0)
            {
                isLeft = true;
                //if(playerPos.x - leftHandRb.position.x < 0.1f) =
                moveToPos = (playerPos.x-leftHandRb.position.x)>0?Vector2.right:Vector2.left;
                leftHandRb.MovePosition(leftHandRb.position + moveToPos*handMoveSpeed*Time.fixedDeltaTime);
            }
            else if(rightHandRb != null && playerPos.x>0)
            {
                isLeft = false;
                moveToPos = (playerPos.x-rightHandRb.position.x)>0?Vector2.right:Vector2.left;
                rightHandRb.MovePosition(rightHandRb.position + moveToPos.normalized*handMoveSpeed*Time.fixedDeltaTime);
            }
        }
        else
        {
            if(leftHandRb != null && playerPos.x<=0)
            {
                leftHandRb.MovePosition(leftHandRb.position + attackPos*handAttackSpeed*Time.fixedDeltaTime);
                if(leftHandRb.position.y<-10 || leftHandRb.position.y>25)
                {
                    attackPos *= -1;
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
        isAttack = false;
        yield return new WaitForSeconds(attackDelay);
        
    }

}