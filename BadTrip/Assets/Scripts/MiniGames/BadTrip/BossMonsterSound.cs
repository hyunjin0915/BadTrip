
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSound : MonoBehaviour
{
    [SerializeField] private AudioCue sfxAudioCue;
    [SerializeField] private AudioCue bgmAudioCue;

    private bool isPlaying = false;
    
    public void Play()
    {
        bgmAudioCue.PlayAudio(3);
        bgmAudioCue.PlayAudio(4);
        isPlaying = true;

        //StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        while (isPlaying) {

            sfxAudioCue.PlayAudio(1);
            yield return new WaitForSeconds(2);
            sfxAudioCue.PlayAudio(2);
            yield return new WaitForSeconds(2);

        }
        
    }



    public void StopPlay()
    {
        isPlaying = false;
        bgmAudioCue.StopAudio(3);
        bgmAudioCue.StopAudio(4);
        StopAllCoroutines();
    }
}
