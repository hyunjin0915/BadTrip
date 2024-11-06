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
    }

    private void OnEnable()
    {
        if (!audioCue.IsSameClip(bgmNum) && manager.GetCanChangeBGM())
        {
            audioCue.StopAudioFade(1.5f);
            audioCue.PlayAudioFade(bgmNum, 1.5f);
        }

    }

    public void PlayBGM(int num, float fade = 1.5f)
    {
        audioCue.StopAudioFade(fade);
        audioCue.PlayAudioFade(num, fade);
    }

    public void StopBGM(float fade)
    {
        audioCue.StopAudioFade(fade);
    }


}
