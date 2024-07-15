using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPst : MonoBehaviour
{
    public SceneInfoSO loadSceneInfo;
    public GameObject CutSceneVcam;
    public AudioCue audioCue;
    
    public void GoToPast()
    {
        audioCue.PlayAudio(3);
        CutSceneVcam.SetActive(false);
        SceneManager.LoadSceneAsync("Home", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("OneRoom");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
