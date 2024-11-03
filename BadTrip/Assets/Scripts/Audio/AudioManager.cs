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

    void Awake()
    {
        sfxEventChannel.audioSourcePlay += PlayAudio;
        bgmEventChannel.audioSourcePlay += PlayAudio;
        bgmEventChannel.audioSourcePlayFade += PlayMusicFade;

        sfxEventChannel.audioSourceStop += StopAudio;
        bgmEventChannel.audioSourceStop += StopAudio;
        bgmEventChannel.audioSourceStopFade += StopMusicFade;

        bgmEventChannel.getAudioName += GetAudioClipName;
    }

    public void PlayAudio(AudioInfoSO audioInfo, Vector2 audioPos)
    {
        audioInfo.ApplyTo(audioSources[audioInfo.audioNum]);
        audioSources[audioInfo.audioNum].transform.position = audioPos;

        if (audioInfo.isOneShot)
        {
            audioSources[audioInfo.audioNum].PlayOneShot(audioInfo.clip);
        } else
        {
            audioSources[audioInfo.audioNum].Play();
        }
    }

    public void StopAudio(AudioInfoSO audioInfo)
    {
        audioSources[audioInfo.audioNum].Stop();
    }

    public void ResetAudioSource(AudioSource[] audioSources) // 오디오 소스 오브젝트 모두 비활성화
    {
        asPool.DisableAS(audioSources);
    }

    public string GetAudioClipName(int num)
    {
        return audioSources[num].isPlaying ? audioSources[num].clip.name : "0";
    }

    public void PlayMusicFade(AudioInfoSO audioInfo, float fade)
    {
        audioSources[audioInfo.audioNum].clip = audioInfo.clip;
        audioSources[audioInfo.audioNum].volume = 0;
        audioSources[audioInfo.audioNum].loop = false;
        audioSources[audioInfo.audioNum].Play();

        StartCoroutine(PlayFade(audioInfo.vol, fade, audioInfo.audioNum));
    }

    public IEnumerator PlayFade(float volume, float fade, int audioNum)
    {
        float ff = fade / 0.1f;
        float fv = volume / ff;
        float f = 0;

        while (f <= volume)
        {
            audioSources[audioNum].volume = f;
            f += fv;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StopMusicFade(float fade)
    {
        int audioNum;
        for (audioNum = 0; audioNum < 3; audioNum++)
        {
            if (audioSources[audioNum].isPlaying)
            {
                StartCoroutine(StopFade(fade, audioNum));
                break;
            }
        }
    }

    public IEnumerator StopFade(float fade, int audioNum)
    {
        float ff = fade / 0.1f;
        float v = audioSources[audioNum].volume;
        float fv = v / ff;
        float f = v;

        while (f > 0)
        {
            audioSources[audioNum].volume = f;
            f -= fv;
            yield return new WaitForSeconds(0.1f);
        }

        audioSources[audioNum].Stop();
        audioSources[audioNum].clip = null;
    }
}
