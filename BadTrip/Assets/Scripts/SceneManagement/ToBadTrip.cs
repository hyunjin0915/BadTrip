using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBadTrip : MonoBehaviour
{
    public SceneInfoSO loadSceneInfo;


   public void GoGame()
    {
        SceneManager.LoadSceneAsync("BadTrip", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Store");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
