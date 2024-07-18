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
        SceneManager.LoadSceneAsync("MethBug", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
        StartCoroutine(EndLoadingScreen());
    }
    IEnumerator ShowLoadingScreen()
   {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
   }
   IEnumerator EndLoadingScreen()
   {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1.0f);
   }

}
