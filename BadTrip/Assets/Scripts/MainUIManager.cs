using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;

    public void SelectBtn()
    {
        audioCue.PlayAudio(1);
    }

    public void PlayClickBtn()
    {
        audioCue.PlayAudio(0);
    }
}
