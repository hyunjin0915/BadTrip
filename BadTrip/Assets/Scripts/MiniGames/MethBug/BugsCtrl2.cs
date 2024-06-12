using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BugsCtrl2 : MonoBehaviour
{
    int vec;
    public int speed;
    private float randomAngle;
    private float randomAngle2;
    private bool isTurn = false;

    private Rigidbody2D myRigid;
    SpriteRenderer spriteRenderer;
    public Sprite afterImg;
    public Sprite scarImg;
    private bool isActive;
    [SerializeField] 
    GameObject gameManager;
    [SerializeField]
    private LoadSceneSO MethBugSL_EventChannel;

    [SerializeField] private AudioCue audioCue;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        vec = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            Moving();
        }
    }
    private void Moving()
    {
        myRigid.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        Vector2 front = new Vector2(transform.position.x + vec*0.5f, transform.position.y);
        Debug.DrawRay(front, transform.up, new Color(0, 1, 0));
        RaycastHit2D rayHitBorder = Physics2D.Raycast(front, transform.up, 4, LayerMask.GetMask("Border"));
        if(rayHitBorder.collider != null)
        {
            ChangeDir();
        }
    }
    private void ChangeDir()
    {
        randomAngle = Random.Range(-90f, -45f);
        transform.Rotate(0f,0f,randomAngle);
    }
    public IEnumerator MoveAgainBug()
    {
        yield return new WaitForSeconds(5.0f);
        speed = 5;
    }
    private void OnMouseDown()
    {
        if(isActive)
        {
            audioCue.PlayAudio(0);

            if (speed == 0)
            {
                StartCoroutine(ChangeBugImg());
                int _bugCnt = --gameManager.GetComponent<MethBugManager>().BugCnt;
                if(_bugCnt==0)
                {
                    MethBugSL_EventChannel.RaiseEvent();
                } 
            }
            else
            {
                speed = 0;
                StartCoroutine(MoveAgainBug());
            }
        }
    }
    private IEnumerator ChangeBugImg()
    {
        spriteRenderer.sprite = afterImg;
        yield return new WaitForSeconds(1.0f);
        isActive = false;
    }
}
