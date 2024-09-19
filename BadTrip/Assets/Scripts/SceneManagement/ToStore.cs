using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStore : MonoBehaviour
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
        SceneManager.LoadSceneAsync("StageOne", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Home");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
