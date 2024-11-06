using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Fungus
{
    [CommandInfo("Audio",
                 "Play Music Fade",
                 "Fade로 music 플레이")]
    [AddComponentMenu("")]
    public class PlayMusicFade : Command
    {

        [Tooltip("Music sound clip to play")]
        [SerializeField] protected AudioInfoSO audioInfoSO;

        [Tooltip("fade 기간")]
        [SerializeField] protected float fadeDuration = 1f;

        public override void OnEnter()
        {
            var musicManager = FungusManager.Instance.MusicManager;

            musicManager.PlayMusicFade(audioInfoSO.audioMixerGroup, audioInfoSO.clip, audioInfoSO.vol, fadeDuration);

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(242, 209, 176, 255);
        }
    }
}


