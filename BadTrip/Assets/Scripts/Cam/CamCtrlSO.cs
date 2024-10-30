using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Cam")]
public class CamCtrlSO : ScriptableObject
{
    public GameObject CurVCam;

    public event Action OnVCamChanged;

    public void ChangeVCam(GameObject _VCam)
    {
        CurVCam = _VCam;
        OnVCamChanged?.Invoke();
    }
}
