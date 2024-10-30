using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHallucination : MonoBehaviour
{
    [SerializeField] private RoomBug roomBug;
    int vec = 1;

    [SerializeField] private Rigidbody2D myRigid;

    public float speed;

    private float randomAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roomBug.isActive)
        {
            Moving();
        } else
        {
            gameObject.SetActive(false);
        }
    }

    private void Moving()
    {
        myRigid.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        Vector2 front = new Vector2(transform.position.x + vec * 0.5f, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            randomAngle = Random.Range(-45f, 45f) + 180;
            transform.Rotate(0f, 0f, randomAngle);
        }
    }

}
