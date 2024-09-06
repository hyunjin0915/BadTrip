using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float jumpForce = 5f;

    private float applyRunSpeed;

    //필요한 컴포넌트
    private Rigidbody2D myRigid;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    Vector2 movement;

    private bool isGround = true;

    private bool IsMoving
    {
        get
        {
            return movement.x != 0 || movement.y != 0;
        }
    }


    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawingRay();
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Run();
        Jump();

        if (IsMoving)
        {
            myAnimator.SetBool("IsWalking", true);
        } else
        {
            myAnimator.SetBool("IsWalking", false);
        }
    }
    void Move()
    {
        myRigid.velocity = new Vector2(movement.x *(walkSpeed+applyRunSpeed), myRigid.velocity.y);
        //myRigid.MovePosition(myRigid.position + movement * (walkSpeed+applyRunSpeed) * Time.fixedDeltaTime);
        if (movement.x > 0) // 오른쪽
        {
            mySpriteRenderer.flipX = true;
        }
        else if (movement.x < 0)// 왼쪽
        {
            mySpriteRenderer.flipX = false;
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            applyRunSpeed = runSpeed;
        else
            applyRunSpeed = 0;
    }
    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && isGround)
        {
            myAnimator.SetBool("IsJumping", true);
            myRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void DrawingRay()
    {
        Debug.DrawRay(transform.position,Vector2.down * 2, new Color(0, 1, 0));
        RaycastHit2D rayHitBorder = Physics2D.Raycast(transform.position,Vector2.down, 2, LayerMask.GetMask("Ground"));
        if(rayHitBorder.collider!=null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (myRigid.velocity.y < 0)
        {
            if (rayHitBorder.distance < 0.5f)
            {
                myAnimator.SetBool("IsJumping", false);
            }
        }
    }
}
