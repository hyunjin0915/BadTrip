using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangActive : MonoBehaviour
{
    //public GameObject bangMark;
    public GameObject spaceMark;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //bangMark.SetActive(true);
            spaceMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //bangMark.SetActive(false);
            spaceMark.SetActive(false);
        }
    }
    
}
