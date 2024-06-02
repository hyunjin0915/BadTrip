using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MethBugEnd : MonoBehaviour
{
    [SerializeField]
    private LoadSceneSO MethBugSL_EventChannel;
    private void OnEnable()
    {
        MethBugSL_EventChannel.OnLoadingScene += EndGame;
    }
    private void OnDisable()
    {
        MethBugSL_EventChannel.OnLoadingScene -= EndGame;
    }

    private void EndGame()
    {
        SceneManager.LoadSceneAsync("OneRoom", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MethBug");
    }
}
