using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSchool : MonoBehaviour
{
    public Animator transition;

    [SerializeField]
    private LoadSceneSO toSchoolSL_EventChannel;
    private void OnEnable()
    {
        toSchoolSL_EventChannel.OnLoadingScene += GoGame;
    }
    private void OnDisable()
    {
        toSchoolSL_EventChannel.OnLoadingScene -= GoGame;
    }

    private void GoGame()
    {
        StartCoroutine(ShowLoadingScreen());
    }
    IEnumerator ShowLoadingScreen()
   {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("School", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("BadTrip");
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
   }
 
}
