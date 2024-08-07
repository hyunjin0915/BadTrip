using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public AudioManager audioMng;
    public string sceneName;

    [SerializeField]
    private LoadSceneSO backToMainSL_EventChannel;
    private SceneInfoSO loadSceneInfo;



    // Start is called before the first frame update
    private void OnEnable()
    {
        backToMainSL_EventChannel.OnLoadingScene += BackToMain;
    }

    private void OnDisable()
    {
        backToMainSL_EventChannel.OnLoadingScene -= BackToMain;
    }

    public void SetMasterVol(float v) // ÀüÃ¼ º¼·ý ¼³Á¤
    {
        audioMng.SetGroupVolume("Master", v);
    }
    public void SetBGMVol(float v) // BGM º¼·ý ¼³Á¤
    {
        audioMng.SetGroupVolume("BGM", v);
    }

    public void SetSFXVol(float v) // SFX º¼·ý ¼³Á¤
    {
        audioMng.SetGroupVolume("SFX", v);
    }

    public void BackToMain()
    {
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneName);
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
