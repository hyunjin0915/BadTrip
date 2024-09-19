using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private AudioCue audioCue;
    [SerializeField] private MapInteractionSetting mapInteractionSetting;
    [SerializeField] private PlayerDataSO playerDataSO;

    private QuestManager questManager;
    private SaveManager saveManager;
    private JsonData data;

    private void Start()
    {
        questManager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
    }

    public void SelectBtn()
    {
        audioCue.PlayAudio(1);
    }

    public void PlayClickBtn()
    {
        audioCue.PlayAudio(0);
    }

    public void LoadData()
    {
        data = saveManager.LoadData();
    }

    public void GoScene()
    {
        mapInteractionSetting.GoScene(data.sceneName);
    }

    public void NewGame()
    {
        playerDataSO.playerName = "³ª";
        playerDataSO.animLayer = 0;
        
    }
}
