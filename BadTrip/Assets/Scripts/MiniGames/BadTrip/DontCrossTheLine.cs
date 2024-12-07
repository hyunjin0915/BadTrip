using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCrossTheLine : MonoBehaviour
{
    private CapsuleCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Border"))
        {
            myCollider.isTrigger = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Border"))
        {
            myCollider.isTrigger = true;
        }
    }
}
