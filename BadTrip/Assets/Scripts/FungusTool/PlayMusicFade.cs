using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Audio",
                 "Play Music Fade",
                 "Fade로 music 플레이")]
    [AddComponentMenu("")]
    public class PlayMusicFade : Command
    {

        [Tooltip("Music sound clip to play")]
        [SerializeField] protected AudioClip musicClip;

        [Tooltip("볼륨")]
        [SerializeField] protected float volume = 0.5f;

        [Tooltip("fade 기간")]
        [SerializeField] protected float fadeDuration = 1f;

        public override void OnEnter()
        {
            var musicManager = FungusManager.Instance.MusicManager;

            musicManager.PlayMusicFade(musicClip, volume, fadeDuration);

            Continue();
        }

        public override string GetSummary()
        {
            if (musicClip == null)
            {
                return "Error: No music clip selected";
            }

            return musicClip.name;
        }

        public override Color GetButtonColor()
        {
            return new Color32(242, 209, 176, 255);
        }
    }
}


