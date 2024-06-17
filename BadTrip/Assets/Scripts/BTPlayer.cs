using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D PlayerRB;
    private Vector2 moveVec2;
    [SerializeField]
    private SpriteRenderer playerSP;
    [SerializeField]
    private Animator playerAnimator;
    private bool canMove = false;
    private bool IsMoving
    {
        get
        {
            return moveVec2.x != 0 || moveVec2.y != 0;
        }
    }

    [Header ("Property")]
    public float speed = 3f;

    public GameObject KeySpace;

    public GameObject KeyUP;
    public GameObject KeyDown;
    public GameObject KeyLeft;
    public GameObject KeyRight;


    public Sprite afterImg_Space;
    public Sprite beforeImg_Space;
    public Sprite afterImg_UP;
    public Sprite beforeImg_UP;
    public Sprite afterImg_Down;
    public Sprite beforeImg_Down;
    public Sprite afterImg_Left;
    public Sprite beforeImg_Left;
    public Sprite afterImg_Right;
    public Sprite beforeImg_Right;

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
        ChangeUIImage();

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //공격
                KeySpace.GetComponent<Image>().sprite = afterImg_Space;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                KeySpace.GetComponent<Image>().sprite = beforeImg_Space;
            }
        }

        // 애니메이션
        if (IsMoving)
        {
            playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }

    }

    public void Move()
    {
        PlayerRB.velocity = moveVec2.normalized * speed * Time.deltaTime;
        if (moveVec2.x > 0) // 오른쪽
        {
            playerSP.flipX = true;
        }
        else if (moveVec2.x < 0)// 왼쪽
        {
            playerSP.flipX = false;
        }
    }

    void ChangeUIImage()
    {
        if(moveVec2.x > 0)
        {
            KeyRight.GetComponent<Image>().sprite = afterImg_Right;
        }
        else if(moveVec2.x < 0)
        {
            KeyLeft.GetComponent<Image>().sprite = afterImg_Left;
        }
        else
        {
            KeyLeft.GetComponent<Image>().sprite = beforeImg_Left;
            KeyRight.GetComponent<Image>().sprite = beforeImg_Right;
        }

        if(moveVec2.y > 0)
        {
            KeyUP.GetComponent<Image>().sprite = afterImg_UP;
        }
        else if(moveVec2.y < 0)
        {
            KeyDown.GetComponent<Image>().sprite = afterImg_Down;
        }
        else
        {
            KeyDown.GetComponent<Image>().sprite = beforeImg_Down;
            KeyUP.GetComponent<Image>().sprite = beforeImg_UP;
        }
    }

    public void SetPlayerAnim(string boolName, bool b)
    {
        playerAnimator.SetBool(boolName, b);
    }

    public void SetCanMove(bool b)
    {
        canMove = b;
    }
}
