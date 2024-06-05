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
    private BoxCollider2D area;

    [Tooltip("attack delay time")]
    public float delayTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("SpawnHands",delayTime);

    }
    void FixedUpdate()
    {
        /*if(leftHandRb != null)
        {
            Vector2 moveToPos = new Vector2(playerPos.x,0);
            leftHandRb.MovePosition(leftHandRb.position + moveToPos*handMoveSpeed*Time.fixedDeltaTime);
        }*/ //외않되..
    }
    private IEnumerator SpawnHands(float delayTime)
    {
        Vector3 spawnPosL = GetRandomLPos();
        Vector3 spawnPosR = GetRandomRPos();
        playerPos = player.transform.position;

        Instantiate(Lefthand, spawnPosL,Quaternion.identity);
        leftHandRb = Lefthand.GetComponent<Rigidbody2D>();
        Instantiate(Righthand, spawnPosR,Quaternion.identity);
        rightHandRb = Righthand.GetComponent<Rigidbody2D>();

        //area.enabled = false;
        yield return new WaitForSeconds(delayTime);

        //area.enabled = true;
        Debug.Log(playerPos.x);

        StartCoroutine("SpawnHands", delayTime);
    }

    private Vector2 GetRandomLPos()
    {
        Vector2 basePos = transform.position;
        Vector2 size = area.size;

        float posX = basePos.x + Random.Range(-size.x/2f, 0);
        float posY = basePos.y + Random.Range(-size.y/2f, 0);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
    private Vector2 GetRandomRPos()
    {
        Vector2 basePos = transform.position;
        Vector2 size = area.size;

        float posX = basePos.x + Random.Range(0, size.x/2f);
        float posY = basePos.y + Random.Range(0, size.y/2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }}
