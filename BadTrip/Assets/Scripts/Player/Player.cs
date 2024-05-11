using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D pRigidbody;
    private Vector2 moveVec2;

    [Header ("Property")]
    public float speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        pRigidbody.velocity = moveVec2.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        moveVec2.x = Input.GetAxis("Horizontal");
        moveVec2.y = Input.GetAxis("Vertical");
    }

    

    // ¿Ãµø
    public void Move()
    {
        
    }
}
