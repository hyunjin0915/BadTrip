using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSchool : MonoBehaviour
{
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
        SceneManager.LoadSceneAsync("School", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("BadTrip");
    }
}
