using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D target;
    private Rigidbody2D rb;

    Vector2 pos;

    [SerializeField]
    float maxMoving = 2.0f;
    [SerializeField]
    float FindRange = 4f; 
    [SerializeField]
    float speed = 3.0f;

    public bool isFollow = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFollow) MovingMonster();
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
            isFollow = true;
            //Vector2 followVec = (target.position - rb.position) * speed * Time.deltaTime;
            rb.velocity = new Vector2 ((target.position - rb.position).x * speed, rb.velocity.y);
            pos = rb.position;
        }
        else
        {
            isFollow = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }
}
