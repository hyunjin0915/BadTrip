using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VCamActiveBadTrip : MonoBehaviour
{
    public GameObject vCam;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer") && !other.isTrigger)
        {
            vCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer") && !other.isTrigger)
        {
            vCam.SetActive(false);
        }
    }
}