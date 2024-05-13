using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string path;
    private string fileName = "SaveDataFile";
    
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Scripts/JsonFile/";
    }

    public void SaveData(JsonData jsonData, bool pretty = false) // 저장하기
    {
        string data = JsonUtility.ToJson(jsonData, pretty);
        //File.WriteAllText(path + fileName + eventNum, data);
        // eventNum : 진행도 별 데이터를 구분하기 위한 번호
        // 후에 알맞게 수정 가능
    }

    public JsonData LoadData(int eventNum) // 불러오기
    {
        // 후에 수정 가능
        string loadData = File.ReadAllText(path + fileName + eventNum);
        JsonData jsonData = JsonUtility.FromJson<JsonData>(loadData);
        return jsonData;
    }
}
