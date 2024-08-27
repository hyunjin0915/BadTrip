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

    Vector2 movement;

    private bool isGround = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawingRay();
        movement.x = Input.GetAxisRaw("Horizontal");

        DrawRay();
    }

    private void FixedUpdate()
    {
        Move();
        Run();
        Jump();
    }
    void Move()
    {
        myRigid.velocity = new Vector2(movement.x *(walkSpeed+applyRunSpeed), myRigid.velocity.y);
        //myRigid.MovePosition(myRigid.position + movement * (walkSpeed+applyRunSpeed) * Time.fixedDeltaTime);
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
            myRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void DrawingRay()
    {
        Debug.DrawRay(transform.position,Vector2.down, new Color(0, 1, 0));
        RaycastHit2D rayHitBorder = Physics2D.Raycast(transform.position,Vector2.down, 2, LayerMask.GetMask("Ground"));
        if(rayHitBorder.collider!=null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }



    ////
    ///
    private void DrawRay()
    {
        Debug.DrawRay(transform.position, Vector2.right * 2, Color.blue); // 임시 레이 표시

        Physics2D.Raycast(transform.position, Vector2.right, 2);
        
    }
}
