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
        SceneManager.LoadSceneAsync("Store", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
