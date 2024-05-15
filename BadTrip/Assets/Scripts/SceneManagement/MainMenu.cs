using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LoadSceneSO NewGameSL_EventChannel;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    private void OnEnable()
    {
        NewGameSL_EventChannel.OnLoadingScene += StartGame;
    }
    private void OnDisable()
    {
        NewGameSL_EventChannel.OnLoadingScene -= StartGame;
    }
    public void OnClickStartBtn()
    {
        NewGameSL_EventChannel.RaiseEvent();
    }
    public void StartGame()
    {
        ShowLoadingScreen();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("SampleScene",LoadSceneMode.Additive));
        SceneManager.UnloadSceneAsync("Main");
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("PersistentMenuUI",LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
        
    }
   
   public void ShowLoadingScreen()
   {
    //로딩화면
   }

   IEnumerator LoadingScreen()
   {
        float totalProgress = 0f;
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                //로딩바 fillAmount 조절
                yield return null;
            }
        }
   }
}
