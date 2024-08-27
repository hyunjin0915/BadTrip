using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public Animator transition;
    public Dictionary<string, SceneInfoSO> loadSceneInfos = new Dictionary<string, SceneInfoSO>() { 
    };
    private string curSceneName = "Main";

    [SerializeField]
    private LoadSceneSOAll sceneload_EventChannel;

    private void OnEnable()
    {
        sceneload_EventChannel.OnLoadingScene += LoadScene;
    }
    private void OnDisable()
    {
        sceneload_EventChannel.OnLoadingScene -= LoadScene;
    }

    public void LoadScene(string moveSceneName)
    {
        StartCoroutine(LoadSceneCor(moveSceneName));
    }

    IEnumerator LoadSceneCor(string moveSceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(moveSceneName, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(curSceneName);
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfos[moveSceneName]);
        curSceneName = moveSceneName;
    }
}
