using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPst : MonoBehaviour
{
    public SceneInfoSO loadSceneInfo;
    
    public void GoToPast()
    {
        SceneManager.LoadSceneAsync("Home", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}