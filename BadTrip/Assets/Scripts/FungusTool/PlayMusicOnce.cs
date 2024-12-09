// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Plays looping game music. If any game music is already playing, it is stopped. Game music will continue playing across scene loads.
    /// </summary>
    [CommandInfo("Audio",
                 "Play Music Once",
                 "music을 한 번 플레이함.")]
    [AddComponentMenu("")]
    public class PlayMusicOnce : Command
    {
        [Tooltip("Music sound clip to play")]
        [SerializeField] protected AudioInfoSO audioInfoSO;


        [Tooltip("볼륨")]
        [SerializeField] protected float volume = 0.5f;

        #region Public members

        public override void OnEnter()
        {
            var musicManager = FungusManager.Instance.MusicManager;

            musicManager.PlayMusicOnce(audioInfoSO.audioMixerGroup, audioInfoSO.clip, volume);

            Continue();
        }

        public override string GetSummary()
        {
            if (audioInfoSO == null)
            {
                return "Error: No music clip selected";
            }

            return audioInfoSO.name;
        }

        public override Color GetButtonColor()
        {
            return new Color32(242, 209, 176, 255);
        }

        #endregion
    }
}
