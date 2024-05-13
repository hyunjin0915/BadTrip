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

    public void RaisePlayEvent(AudioInfoSO audioInfo, Vector2 audioPos)
    {
        audioSourcePlay.Invoke(audioInfo, audioPos);
    }

    public void RaiseStopEvent(AudioInfoSO audioInfo)
    {
        audioSourceStop.Invoke(audioInfo);
    }
}
