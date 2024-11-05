using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;

    // 플레이어 Move
    [SerializeField] private Rigidbody2D pRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSP;
    private Vector2 moveVec2;
    
    // 상호작용
    private RaycastHit2D hit;
    private Vector2 interPos; // 상호작용 위치
    [SerializeField] private float rayLength = 10f;
    private GameObject scanObj;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private SceneMove sceneManager;

    // 발소리
    [SerializeField] private AudioSource footstepAS;
    public AudioClip footstepClip;

    // 플레이어 Move Control
    public bool canMove = false;

    public bool IsMoving
    {
        get
        {
            return moveVec2.x != 0 || moveVec2.y != 0;
        }
    }

    [Header("Property")]
    public float speed = 1.5f;

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
        if(moveVec2.y>0) interPos = Vector2.up;
        else if(moveVec2.y<0) interPos = Vector2.down;

        DrawRay();

        if (IsMoving)
        {
            playerAnimator.SetBool("IsWalking", true);
            //footstepAS.enabled = true;
        } else
        {
            playerAnimator.SetBool("IsWalking", false);
            //footstepAS.enabled = false;
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, interPos * rayLength, Color.blue); // 임시 레이 표시

        hit = Physics2D.Raycast(transform.position, interPos, rayLength, 1 << 9);
        if(hit.collider != null)
        {
            scanObj = hit.collider.gameObject;
            if(scanObj.CompareTag("Border"))
            {
                //moveVec2 = Vector2.zero; // 요거 ray 벽에 닿으면 플레이어가 안움직여서 잠시 주석처리
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(hit.collider.gameObject.CompareTag("Door"))
                {
                    MapInteractionObject mapInteractionObject = hit.collider.gameObject.GetComponent<MapInteractionObject>();
                    mapInteractionObject?.OnInteraction();
                    MoveToPos moveToPos = hit.collider.gameObject.GetComponent<MoveToPos>();
                    if (moveToPos != null)
                    {
                        sceneManager.LoadMap(moveToPos.moveToPos.transform.position);
                    }
                    questManager.UpdateQuestState(mapInteractionObject?.interactionId);

                } else if (hit.collider.gameObject.CompareTag("Interaction"))
                {
                    MapInteractionObject mapInteractionObject = hit.collider.gameObject.GetComponent<MapInteractionObject>();
                    mapInteractionObject?.OnInteraction();
                    questManager.UpdateQuestState(mapInteractionObject?.interactionId);
                }
            }
        }
        else
            scanObj = null;
    }
    // 이동
    public void Move()
    {
        pRigidbody.velocity = moveVec2.normalized * speed * Time.deltaTime;
        if (moveVec2.x > 0) // 오른쪽
        {
            playerSP.flipX = true;
            interPos = Vector2.right;
            playerDataSO.isFlip = true;
        } else if (moveVec2.x < 0)// 왼쪽
        {
            playerSP.flipX = false;
            interPos = Vector2.left;
            playerDataSO.isFlip = false;
        }
    }

    // 애니메이션
    /*public void SetIsStudent()
    {
        isStudent = FungusManager.Instance.GlobalVariables.GetVariable("isStudent");
    }*/

    public void PlayerSetActive(bool b)
    {
        if (b)
        {
            playerSP.color = new Color(1, 1, 1, 1);
        } else
        {
            playerSP.color = new Color(1, 1, 1, 0);
        }
    }

    #region Animation
    public void SetAnimLayer(int num)
    {
        if (num == 0)
        {
            ActivateLayer(0);
        } else if (num == 1)
        {
            ActivateLayer(1);
        } else if (num == 2)
        {
            ActivateLayer(2);
        } else if(num == 3)
        {
            ActivateLayer(3);
        }
    }

    public void ActivateLayer(int layerIndex)
    {
        for (int i = 0; i < 4; i++)
        {
            playerAnimator.SetLayerWeight(i, 0);
        }

        playerAnimator.SetLayerWeight(layerIndex, 1);
        playerDataSO.animLayer = layerIndex;
    }

    public void SetPlayerAnim(string boolName, bool b)
    {
        playerAnimator.SetBool(boolName, b);
    }

    #endregion

    #region PlayerMoveControl
    public void SetCanMove(bool b)
    {
        canMove = b;
    }

    public void SetCanMoveInt(int i)
    {
        canMove = Convert.ToBoolean(i);
    }

    public void StopPlayer()
    {
        pRigidbody.velocity = Vector3.zero;
    }

    public void SetPlayerPos(Vector2 pos, bool isFlip = false)
    {
        gameObject.transform.position = pos;
        playerSP.flipX = isFlip; // true : 오른쪽 false : 왼쪽

    }

    public void SetPlayerFlip(bool b)
    {
        playerSP.flipX = b;
    }
    #endregion

    #region PlayerFootstepAudio

    public void SetFootstepVolume(float v)
    {
        footstepAS.volume = v;
    }

    public void PlayFootstepAudio()
    {
        footstepAS?.PlayOneShot(footstepClip);
    }
    #endregion

    public void SetSortingLayer(string layer, int order)
    {
        playerSP.sortingLayerName = layer;
        playerSP.sortingOrder = order;
    }

}
