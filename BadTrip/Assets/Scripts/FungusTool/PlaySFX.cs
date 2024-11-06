using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Audio",
                     "Play SFX",
                     "Plays a once-off sound effect. Multiple sound effects can be played at the same time.")]
    [AddComponentMenu("")]
    public class PlaySFX : Command
    {
        [Tooltip("Sound effect clip to play")]
        [SerializeField] protected AudioInfoSO audioInfoSO;

        [Tooltip("Wait until the sound has finished playing before continuing execution.")]
        [SerializeField] protected bool waitUntilFinished;

        protected virtual void DoWait()
        {
            Continue();
        }


        public override void OnEnter()
        {
            if (audioInfoSO == null)
            {
                Continue();
                return;
            }

            var musicManager = FungusManager.Instance.MusicManager;

            musicManager.PlaySound(audioInfoSO.audioMixerGroup, audioInfoSO.clip, audioInfoSO.vol);

            if (waitUntilFinished)
            {
                Invoke("DoWait", audioInfoSO.clip.length);
            }
            else
            {
                Continue();
            }
        }

        public override Color GetButtonColor()
        {
            return new Color32(242, 209, 176, 255);
        }
    }
}
