using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMethBug : MonoBehaviour
{
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
        SceneManager.LoadSceneAsync("MethBug", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
    }
}
