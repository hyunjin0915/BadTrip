using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Vector2 pos;
    [SerializeField]
    float maxMoving = 2.0f;
    [SerializeField]
    float FindRange = 4f; 
    [SerializeField]
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovingMonster();
        FollowingPlayer();
    }

    void MovingMonster()
    {
        Vector2 v = pos;
        v.x += maxMoving * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
    void FollowingPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, FindRange,LayerMask.GetMask("Player"));
        if(playerCollider!=null)
        {
            // 플레이어 향해서 이동 코드 구현
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }
}
