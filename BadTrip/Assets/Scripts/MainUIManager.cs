using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;
    [SerializeField] private PlayerDataSO playerDataSO;

    private QuestManager questManager;
    private JsonData data;

    public GameObject loadWindow;

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

    public void ShowLoadWindow()
    {
        loadWindow.SetActive(true);
    }

    public void ExitLoadWindow()
    {
        loadWindow.SetActive(false);
    }

    public void NewGame()
    {
        playerDataSO.playerName = "³ª";
        playerDataSO.animLayer = 0;
        playerDataSO.isFlip = false;
        playerDataSO.getDC = false;
        questManager.QuestInit();
        audioCue.SetCurBGMNum(-1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
