using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHand : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}
