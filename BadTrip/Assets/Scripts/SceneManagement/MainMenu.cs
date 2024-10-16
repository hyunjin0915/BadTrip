using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
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
    
    public void StartGame()
    {
        StartCoroutine(ShowLoadingScreen());
    }
   public void OnClickStartBtn()
    {
        NewGameSL_EventChannel.RaiseEvent();
    }
 
   IEnumerator ShowLoadingScreen()
   {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("OneRoom",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Main");
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
        
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
