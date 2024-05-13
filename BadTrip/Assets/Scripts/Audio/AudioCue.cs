using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCue : MonoBehaviour
{
    [SerializeField] private AudioInfoSO audioInfo = default;
    [SerializeField] private AudioEventChannelSO audioEventChannel = default;

    public void PlayAudio()
    {
        audioEventChannel.RaisePlayEvent(audioInfo, this.transform.position);
    }

    public void StopAudio()
    {
        audioEventChannel.RaiseStopEvent(audioInfo);
    }
}
