using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;

    private void OnEnable()
    {
        if (!audioCue.IsSameClip(0))
        {
            audioCue.PlayAudio(0);
        }

    }


}
