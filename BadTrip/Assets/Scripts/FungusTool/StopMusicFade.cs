using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Audio",
                 "Stop Music Fade",
                 "Fade로 music 중지")]
    [AddComponentMenu("")]
    public class StopMusicFade : Command
    {

        [Tooltip("fade 기간")]
        [SerializeField] protected float fadeDuration = 1f;

        public override void OnEnter()
        {
            var musicManager = FungusManager.Instance.MusicManager;

            musicManager.StopMusicFade(fadeDuration);

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(242, 209, 176, 255);
        }
    }
}


