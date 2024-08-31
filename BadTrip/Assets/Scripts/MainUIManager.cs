using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;

    private QuestManager questManager;

    private void Start()
    {
        questManager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
    }

    public void SelectBtn()
    {
        audioCue.PlayAudio(1);
    }

    public void PlayClickBtn()
    {
        audioCue.PlayAudio(0);
    }

    public void LoadQuest(int questId)
    {
        questManager.LoadQuest(questId);
    }
}
