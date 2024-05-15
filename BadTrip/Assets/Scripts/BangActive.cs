using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangActive : MonoBehaviour
{
    public GameObject bangMark;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            bangMark.SetActive(true);
        }
    }}
