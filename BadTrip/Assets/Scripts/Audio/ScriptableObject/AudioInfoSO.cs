using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Data/AudioInfoSO")]
public class AudioInfoSO : ScriptableObject
{
    public int audioNum; // 오디오 번호. 가능하면 여러 맵에 공통으로 들어가는 오디오의 경우 1 이나 2 같이 작게 설정. 배경 음악의 경우 0으로 설정, oneShot은 앞번호
    public AudioClip clip;
    public float vol;
    public float pch = 1;
    public bool isLoop;
    public bool isOneShot;
    public float spread;
    public AudioMixerGroup audioMixerGroup;

    public float spatialBlend = 0; // 사운드 2d(0), 3d(1) 조절
    public float minDistance = 1f; // 이 거리 내에서는 최고 음량 유지
    public float maxDistance = 500f; // 이 거리 내에서는 음량이 감소, 완전히 벗어나면 소리가 들리지 않음

    public void ApplyTo(AudioSource audioSource)
    {
        audioSource.clip = this.clip;
        audioSource.volume = vol;
        audioSource.pitch = pch;
        audioSource.loop = isLoop;
        audioSource.spread = this.spread;
        audioSource.outputAudioMixerGroup = audioMixerGroup;

        audioSource.spatialBlend = this.spatialBlend;
        audioSource.minDistance = this.minDistance;
        audioSource.maxDistance = this.maxDistance;
    }
}
