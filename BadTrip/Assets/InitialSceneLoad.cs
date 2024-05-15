using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneLoad : MonoBehaviour
{
    [SerializeField]
    private LoadSceneSO initialSL_EventChannel;

    // Start is called before the first frame update
    void Start()
    {
        initialSL_EventChannel.RaiseEvent();
    }
    private void OnEnable()
    {
        initialSL_EventChannel.OnLoadingScene += LoadInitialScenes;
    }
    private void OnDisable()
    {
        initialSL_EventChannel.OnLoadingScene -= LoadInitialScenes;
    }

    public void LoadInitialScenes()
    {
      SceneManager.LoadSceneAsync("Main",LoadSceneMode.Additive);
    }
}
