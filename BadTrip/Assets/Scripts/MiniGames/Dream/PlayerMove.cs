using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // 발소리
    [SerializeField] private AudioSource footstepAS;
    public AudioClip footstepClip;

    // 상호작용
    private RaycastHit2D hit;
    private Vector2 interPos; // 상호작용 위치
    [SerializeField] private float rayLength = 10f;
    private GameObject scanObj;
    [SerializeField] private PlayerDataSO playerDataSO;

    // 플레이어 Move Control
    public bool canMove = false;

    Vector2 movement;

    private bool isGround = true;

    private bool IsMoving
    {
        get
        {
            return movement.x != 0;
        }
    }

    private bool IsJumping
    {
        get
        {
            return myRigid.velocity.y != 0;
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
        DrawRay();
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
            Run();
            Jump();
        }

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
            interPos = Vector2.right;
        }
        else if (movement.x < 0)// 왼쪽
        {
            mySpriteRenderer.flipX = false;
            interPos = Vector2.left;
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
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGround)
        {
            myRigid.velocity = Vector2.zero;
            myRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            GetComponent<CapsuleCollider2D>().isTrigger=true;
        }

        if (IsJumping)
        {
            myAnimator.SetBool("IsJumping", true);
        } else
        {
            myAnimator.SetBool("IsJumping", false);
        }
    }
    void DrawingRay()
    {
        Debug.DrawRay(transform.position,Vector2.down * 7, new Color(0, 1, 0));
        RaycastHit2D rayHitBorder = Physics2D.Raycast(transform.position,Vector2.down,7, LayerMask.GetMask("Ground"));
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
            GetComponent<CapsuleCollider2D>().isTrigger=false;
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, interPos * rayLength, Color.blue); // 임시 레이 표시

        hit = Physics2D.Raycast(transform.position, interPos, rayLength, 1 << 9);
        if (hit.collider != null)
        {
            scanObj = hit.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hit.collider.gameObject.CompareTag("Interaction"))
                {
                    MapInteractionObject mapInteractionObject = hit.collider.gameObject.GetComponent<MapInteractionObject>();
                    mapInteractionObject?.OnInteraction();
                    //questManager.UpdateQuestState(mapInteractionObject?.interactionId);

                    // if 상호작용한 오브젝트가 드림캐쳐면 ~~
                }
            }
        }
        else
            scanObj = null;
    }

    public void PlayFootstepAudio()
    {
        footstepAS?.PlayOneShot(footstepClip);
    }

    public void SetCanMove(bool b)
    {
        canMove = b;
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<CapsuleCollider2D>().isTrigger=true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<CapsuleCollider2D>().isTrigger=false;
    }*/

    public void SetDreamcatcher(bool b)
    {
        playerDataSO.getDC = b;
    }
}
