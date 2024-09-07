using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public AudioManager audioMng;
    private string sceneName = "Main";

    [SerializeField]
    /*private LoadSceneSO backToMainSL_EventChannel;
    [SerializeField]*/
    private SceneInfoSO loadSceneInfo;

    public GameObject settingWindow;
    //public Slider bgmSlider;

    [SerializeField]
    private GameObject player;



    /*// Start is called before the first frame update
    private void OnEnable()
    {
        backToMainSL_EventChannel.OnLoadingScene += BackToMain;
    }

    private void OnDisable()
    {
        backToMainSL_EventChannel.OnLoadingScene -= BackToMain;
    }*/

    public void SetMasterVol(float v) // ÀüÃ¼ º¼·ý ¼³Á¤
    {
        if (v <= -39f)
        {
            v = -80f;
        }
        
        audioMng.SetGroupVolume("Master", v);
    }
    public void SetBGMVol(float v) // BGM º¼·ý ¼³Á¤
    {
        if (v <= -39f)
        {
            v = -80f;
        }

        audioMng.SetGroupVolume("BGM", v);
    }

    public void SetSFXVol(float v) // SFX º¼·ý ¼³Á¤
    {
        if (v <= -39f)
        {
            v = -80f;
        }

        audioMng.SetGroupVolume("SFX", v);
    }

    public void BackToMain()
    {
        if (!sceneName.Equals("Main"))
        {
            SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(sceneName);
            GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
            player.transform.position = new Vector2(31.6f, -9.2f);
            player.GetComponent<Player>().SetAnimLayer(0);
        }
    }

    public void OnOffSetting(bool b)
    {
        settingWindow.SetActive(b);
    }

    public void SetSceneName(string name)
    {
        sceneName = name;
    }
}
