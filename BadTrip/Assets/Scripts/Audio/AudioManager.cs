using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSourcePoolSO asPool;

    public AudioMixer audioMixer;

    [SerializeField] private AudioEventChannelSO sfxEventChannel = default;
    [SerializeField] private AudioEventChannelSO bgmEventChannel = default;

    public AudioSource[] audioSources;

    [Range(0f, 1f)]
    [SerializeField] private float masterVol = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float bgmVol = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float sfxVol = 1f;

    public void SetGroupVolume(string parameterName, float volume)
    {
        audioMixer.SetFloat(parameterName, volume);
    }

    void Start()
    {
        sfxEventChannel.audioSourcePlay += PlayAudio;
        bgmEventChannel.audioSourcePlay += PlayAudio;

        sfxEventChannel.audioSourceStop += StopAudio;
        bgmEventChannel.audioSourceStop += StopAudio;
    }

    public void PlayAudio(AudioInfoSO audioInfo, Vector2 audioPos)
    {
        AudioSource audioSource = asPool.EnableAS(audioSources, audioInfo.audioNum);
        audioInfo.ApplyTo(audioSource);
        audioSource.transform.position = audioPos;
        audioSource.Play();
    }

    public void StopAudio(AudioInfoSO audioInfo)
    {
        AudioSource audioSource = asPool.EnableAS(audioSources, audioInfo.audioNum);
        audioSource.Stop();
    }

    public void ResetAudioSource(AudioSource[] audioSources) // 오디오 소스 오브젝트 모두 비활성화
    {
        asPool.DisableAS(audioSources);
    }
}
