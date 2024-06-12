using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;

    private void OnEnable()
    {
        audioCue.PlayAudio(0);
    }
}
