using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    GameObject tPlayer;
    
    public void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        followPlayer();
    }

    public void followPlayer()
    {
        tPlayer = GameObject.FindGameObjectWithTag("Player");
        vCam.Follow = tPlayer.transform;
    }
}
