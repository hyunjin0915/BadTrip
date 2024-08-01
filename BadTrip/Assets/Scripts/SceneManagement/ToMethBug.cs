using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMethBug : MonoBehaviour
{
    public Animator transition;

    [SerializeField]
    private LoadSceneSO toMethBugSL_EventChannel;
    private void OnEnable()
    {
        toMethBugSL_EventChannel.OnLoadingScene += GoGame;
    }
    private void OnDisable()
    {
        toMethBugSL_EventChannel.OnLoadingScene -= GoGame;
    }

    private void GoGame()
    {
        StartCoroutine(ShowLoadingScreen());
    }
    IEnumerator ShowLoadingScreen()
   {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("MethBug", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
   }
   
}
