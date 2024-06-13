using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    public GameObject vfxPrefab;

    [SerializeField] AudioCue audioCue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hand"))
        {
            audioCue.PlayAudio(0);

            Instantiate(vfxPrefab, collision.transform.position,Quaternion.identity);
        }
    }
}
