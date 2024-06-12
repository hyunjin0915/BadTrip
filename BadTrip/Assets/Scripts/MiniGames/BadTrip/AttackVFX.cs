using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    public GameObject vfxPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hand"))
        {
            Instantiate(vfxPrefab, collision.transform.position,Quaternion.identity);
        }
    }
}
