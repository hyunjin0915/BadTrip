using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            Destroy(other.gameObject);
            //gameObject.SetActive(false);
        }
    }
}
