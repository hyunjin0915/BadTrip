using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class VCamActiveBadTrip : MonoBehaviour
{
    public GameObject vCam;
    public GameObject backGround;
    public GameObject spawn;
    
    public  CamCtrlSO camCtrlSO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer") && !other.isTrigger)
        {
            vCam.SetActive(true);
            camCtrlSO.ChangeVCam(vCam);

            if(vCam.name.Equals("CamFiveVCam"))
            {
                if(spawn!=null) spawn.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer") && !other.isTrigger)
        {
            vCam.SetActive(false);
        }
        if(vCam.name.Equals("CamFiveVCam"))
        {
            if(spawn!=null) spawn.SetActive(false);
        }
    }
}
