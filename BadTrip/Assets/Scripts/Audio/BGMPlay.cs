using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;
    public int bgmNum;
    private AudioManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        if (audioCue.GetCurBGMNum() >= 100)
        {
            bgmNum = audioCue.GetCurBGMNum() - 200;
        }
        
        if (manager.GetCanChangeBGM() && !audioCue.IsSameClip(bgmNum))
        {
            audioCue.SetCurBGMNum(audioCue.GetCurBGMNum() - 200);
            audioCue.StopAudioFade(1.5f);
            audioCue.PlayAudioFade(bgmNum, 1.5f);
        }
    }

    public void PlayBGM(int num, float fade = 1.5f)
    {
        audioCue.SetCurBGMNum(num);
        audioCue.StopAudioFade(fade);
        audioCue.PlayAudioFade(num, fade);
    }

    public void StopBGM(float fade)
    {
        audioCue.StopAudioFade(fade);
    }

    public void OnlyPlayBGM(int num, float fade = 1.5f)
    {
        audioCue.SetCurBGMNum(num);
        audioCue.PlayAudioFade(num, fade);
    }
}
