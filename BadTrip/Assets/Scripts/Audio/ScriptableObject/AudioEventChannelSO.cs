using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Audio Event Channel")]
public class AudioEventChannelSO : ScriptableObject
{
    public Action<AudioInfoSO, Vector2> audioSourcePlay; // 오디오 출력

    public Action<AudioInfoSO> audioSourceStop; // 오디오 정지

    public Func<int, string> getAudioName; // 현재 같은 오디오가 출력되고 있는가

    public void RaisePlayEvent(AudioInfoSO audioInfo, Vector2 audioPos)
    {
        audioSourcePlay.Invoke(audioInfo, audioPos);
    }

    public void RaiseStopEvent(AudioInfoSO audioInfo)
    {
        audioSourceStop.Invoke(audioInfo);
    }

    public string RaiseGetAudioName(int num)
    {
        return getAudioName.Invoke(num);
    }
}
