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
        path = Application.dataPath + "/Resources/";
    }

    public void SaveData(int num, bool pretty = false) // 저장하기
    {
        SetJsonData();
        string data = JsonUtility.ToJson(jsonData, pretty);
        File.WriteAllText(path + fileName + num, data);
    }

    public JsonData LoadData(int num) // 불러오기
    {
        bool b = LoadJson(num);
        if (b)
        {
            LoadJson(num);
            GetJsonData();
            return jsonData;
        }

        return null;
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
        jsonData.getDreamcatcher = playerDataSO.getDC;
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
        playerDataSO.getDC = jsonData.getDreamcatcher;
    }

    public bool LoadJson(int num)
    {
        if (File.Exists(path + fileName + num))
        {
            string loadData = File.ReadAllText(path + fileName + num);
            jsonData = JsonUtility.FromJson<JsonData>(loadData);

            // TextAsset file = Resources.Load<TextAsset>(fileName + num.ToString());


            // if(file == null){
            //     Debug.Log(fileName + num.ToString());
            // }
            // jsonData = JsonUtility.FromJson<JsonData>(file.ToString());
            return true;
        }

        return false;
    }

    public string GetPlayerName(int num)
    {
        bool b = LoadJson(num);
        if (b)
        {
            return jsonData.playerName;
        }
        return null;
    }
}
