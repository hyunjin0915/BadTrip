using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D pRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSP;
    private Vector2 moveVec2;
    private bool canMove = false;
    //private bool isStudent = false;
    private bool IsMoving
    {
        get
        {
            return moveVec2.x != 0 || moveVec2.y != 0;
        }
    }

    [Header("Property")]
    public float speed = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveVec2.x = Input.GetAxis("Horizontal");
        moveVec2.y = Input.GetAxis("Vertical");

        if (IsMoving)
        {
            playerAnimator.SetBool("IsWalking", true);
        } else
        {
            playerAnimator.SetBool("IsWalking", false);
        }
    }

    // 이동
    public void Move()
    {
        pRigidbody.velocity = moveVec2.normalized * speed;
        if (moveVec2.x > 0) // 오른쪽
        {
            playerSP.flipX = true;
        } else if (moveVec2.x < 0)// 왼쪽
        {
            playerSP.flipX = false;
        }
    }

    // 애니메이션
    /*public void SetIsStudent()
    {
        isStudent = FungusManager.Instance.GlobalVariables.GetVariable("isStudent");
    }*/

    public void SetAnimLayer()
    {
        if (FungusManager.Instance.GlobalVariables.GetVariable("isStudent"))
        {
            ActivateLayer(1);
        } else
        {
            ActivateLayer(0);
        }
    }

    public void ActivateLayer(int layerIndex)
    {
        int otherLayer = (layerIndex == 1) ? 2 : 1;

        playerAnimator.SetLayerWeight(layerIndex, 1);
        playerAnimator.SetLayerWeight(otherLayer, 0);
    }

    public void SetPlayerAnim(string boolName, bool b)
    {
        playerAnimator.SetBool(boolName, b);
    }

    public void SetCanMove(bool b)
    {
        canMove = b;
    }

    public void SetCanMoveInt(int i)
    {
        canMove = Convert.ToBoolean(i);
    }
}
