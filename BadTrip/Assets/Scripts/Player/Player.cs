using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] private Rigidbody2D pRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSP;
    private Vector2 moveVec2;
    private bool canMove = false;

    private RaycastHit2D hit;
    private Vector2 interPos; // 상호작용 위치
    [SerializeField] private float rayLength = 10f;
    //private bool isStudent = false;
    private GameObject scanObj;
    [SerializeField] private AudioSource footstepAS;

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
        if (playerSP.flipX) // 오른쪽
        {
            interPos = Vector2.right;
        } else
        {
            interPos = Vector2.left;
        }
        if(moveVec2.y>0) interPos = Vector2.up;
        else if(moveVec2.y<0) interPos = Vector2.down;

        DrawRay();

        if (IsMoving)
        {
            playerAnimator.SetBool("IsWalking", true);
            footstepAS.enabled = true;
        } else
        {
            playerAnimator.SetBool("IsWalking", false);
            footstepAS.enabled = false;
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, interPos * rayLength, Color.blue); // 임시 레이어 표시

        hit = Physics2D.Raycast(transform.position, interPos, rayLength, 1 << 9);
        if(hit.collider != null)
        {
            scanObj = hit.collider.gameObject;
            if(scanObj.CompareTag("Border"))
            {
                moveVec2 = Vector2.zero;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(hit.collider.gameObject.CompareTag("Door"))
                {
                    gameObject.transform.position = hit.collider.gameObject.GetComponent<MoveToPos>().moveToPos.transform.position;
                } else if (hit.collider.gameObject.CompareTag("Interaction"))
                {
                    hit.collider.gameObject.GetComponent<MapInteractionObject>().OnInteraction();
                }
            }
        }
        else
            scanObj = null;
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
            ActivateLayer(2);
        } else
        {
            ActivateLayer(1);
        }
    }

    public void ActivateLayer(int layerIndex)
    {
        int otherLayer = (layerIndex == 1) ? 2 : 1;

        playerAnimator.SetLayerWeight(layerIndex, 1);
        playerAnimator.SetLayerWeight(otherLayer, 0);
        playerAnimator.SetLayerWeight(0, 0);
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

    public void SetFootstepVolume(float v)
    {
        footstepAS.volume = v;
    }
}
