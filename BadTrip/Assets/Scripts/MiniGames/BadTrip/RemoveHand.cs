using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHand : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hand"))
        {
            Destroy(collision.gameObject);
            //gameObject.SetActive(false);
        }
    }
}
