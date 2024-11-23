using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AudioListSO")]
public class AudioListSO : ScriptableObject
{
    public AudioInfoSO[] audioBGMList;
}
