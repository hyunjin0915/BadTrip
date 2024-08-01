using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MethBugEnd : MonoBehaviour
{
    public Animator transition;

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
        StartCoroutine(ShowLoadingScreen());
    }

    IEnumerator ShowLoadingScreen()
   {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("OneRoom", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MethBug");
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
   }
  
}
