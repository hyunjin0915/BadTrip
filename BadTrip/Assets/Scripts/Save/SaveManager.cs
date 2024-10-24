using Fungus;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string path;
    private string fileName = "SaveDataFile";
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private SceneMove sceneMove;
    [SerializeField] private GameObject player;
    private JsonData jsonData;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Scripts/JsonFile/";
    }

    public void SaveData(bool pretty = false) // 저장하기
    {
        SetJsonData();
        string data = JsonUtility.ToJson(jsonData, pretty);
        File.WriteAllText(path + fileName, data);
    }

    public JsonData LoadData() // 불러오기
    {
        // 후에 수정 가능
        string loadData = File.ReadAllText(path + fileName);
        jsonData = JsonUtility.FromJson<JsonData>(loadData);
        GetJsonData();
        return jsonData;
    }

    public void SetJsonData()
    {
        jsonData = new JsonData();
        jsonData.playerName = playerDataSO.playerName;
        jsonData.questId = questManager.curQuestId;
        jsonData.questPro = questManager.GetQuestPro().ToArray();
        jsonData.sceneName = sceneMove.curSceneName;
        jsonData.playerPos = player.transform.position;
        jsonData.animLayer = playerDataSO.animLayer;
        jsonData.isflip = playerDataSO.isFlip;
    }

    public void GetJsonData()
    {
        playerDataSO.playerName = jsonData.playerName;
        questManager.curQuestId = jsonData.questId;
        questManager.SetQuestPro(jsonData.questPro);
        //sceneMove.curSceneName = jsonData.sceneName;
        player.transform.position = jsonData.playerPos;
        playerDataSO.animLayer = jsonData.animLayer;
        player.GetComponent<SpriteRenderer>().flipX = jsonData.isflip;
    }
}
