using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public AudioManager audioMng;

    [SerializeField]
    private SceneInfoSO loadSceneInfo;

    public GameObject settingWindow;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject saveWindow;
    [SerializeField]
    private GameObject checkHome;
    [SerializeField]
    private GameObject checkSave;

    [SerializeField]
    private SceneMove sceneMove;


    private bool isActive = false;

    private bool isDialog = true;

    public Animator transition;
    public Animator transition_White;

    private void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (isActive)
                {
                    isActive = false;
                    OnOffSetting(isActive);
                }
                else
                {
                    isActive = true;
                    OnOffSetting(isActive);
                }
            }
        }
    }



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
        if (!sceneMove.curSceneName.Equals("Main") || !sceneMove.curSceneName.Equals("StageOne"))
        {
            StartCoroutine(GoMain());
        }
    }

    public void BackToMainWhite()
    {
        transition_White.gameObject.SetActive(true);
        StartCoroutine(GoMainWhite());
    }

    IEnumerator GoMain()
    {
        Time.timeScale = 1;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneMove.curSceneName);
        sceneMove.curSceneName = "Main";
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
        player.transform.position = new Vector2(31.6f, -9.2f);
        player.GetComponent<Player>().SetAnimLayer(0);
        player.GetComponent<Player>().PlayerInit();
        OnOffSetting(false);
        ActiveCheckHome(false);
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
    }

    IEnumerator GoMainWhite()
    {
        Time.timeScale = 1;
        transition_White.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneMove.curSceneName);
        sceneMove.curSceneName = "Main";
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
        player.transform.position = new Vector2(31.6f, -9.2f);
        player.GetComponent<Player>().SetAnimLayer(0);
        player.GetComponent<Player>().PlayerInit();
        yield return new WaitForSeconds(1.0f);
        transition_White.SetTrigger("End");
        yield return new WaitForSeconds(1.0f);
        transition_White.SetTrigger("false");
    }

    public void ShowSaveWindow()
    {
        if (!sceneMove.curSceneName.Equals("Main"))
        {
            saveWindow.SetActive(true);
        }
    }

    public void ExitSaveWindow()
    {
        saveWindow.SetActive(false);
    }

    public void ActiveCheckHome(bool b)
    {
        checkHome.SetActive(b);
    }

    public void InactiveCheckSave()
    {
        checkSave.SetActive(false);
    }



    public void OnOffSetting(bool b)
    {
        if (b)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
        settingWindow.SetActive(b);
    }

    public void SetIsDialog(bool b)
    {
        isDialog = b;
    }
}
