using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;
    public int bgmNum;

    private void OnEnable()
    {
        if (!audioCue.IsSameClip(bgmNum))
        {
            audioCue.StopAudioFade(1.5f);
            audioCue.PlayAudioFade(bgmNum, 1.5f);
        }

    }

    public void PlayBGM(int num)
    {
        audioCue.StopAudioFade(1.5f);
        audioCue.PlayAudioFade(num, 1.5f);
    }


}
