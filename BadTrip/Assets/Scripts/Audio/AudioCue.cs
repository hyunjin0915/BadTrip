using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCue : MonoBehaviour
{
    [SerializeField] private AudioInfoSO[] audioInfos = default;
    [SerializeField] private AudioEventChannelSO audioEventChannel = default;

    public void PlayAudio(int num)
    {
        audioEventChannel.RaisePlayEvent(audioInfos[num], this.transform.position);
    }

    public void StopAudio(int num)
    {
        audioEventChannel.RaiseStopEvent(audioInfos[num]);
    }

    public void PlayAudioFade(int num, float fade)
    {
        audioEventChannel.RaisePlayFadeEvent(audioInfos[num], fade);
    }

    public void StopAudioFade(float fade)
    {
        audioEventChannel.RaiseStopFadeEvent(fade);
    }


    public bool IsSameClip(int num)
    {
        return audioInfos[num].clip.name == audioEventChannel.getAudioName(audioInfos[num].audioNum);
    }
}
