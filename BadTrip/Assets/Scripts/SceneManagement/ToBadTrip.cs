using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBadTrip : MonoBehaviour
{
    public SceneInfoSO loadSceneInfo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GoGame();
        }
    }


    private void GoGame()
    {
        SceneManager.LoadSceneAsync("BadTrip", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
