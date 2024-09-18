using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public Animator transition;
    public SerializedDictionary<string, SceneInfoSO> loadSceneInfos = new SerializedDictionary<string, SceneInfoSO>();
    public SerializedDictionary<string, Vector3> loadPlayerPos = new SerializedDictionary<string, Vector3>(); // 씬 이동 시 플레이어 위치 key : 현재씬 이름 + 이동할 씬 이름 value : 좌표와 플레이어가 바라보는 방향 1 : 오른쪽을 바라봄. 0 : 왼쪽을 바라봄
    public string curSceneName = "Main";

    [SerializeField]
    private LoadSceneSOAll sceneload_EventChannel;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private PlayerDataSO playerDataSO;

    private void OnEnable()
    {
        sceneload_EventChannel.OnLoadingScene += LoadScene;
    }
    private void OnDisable()
    {
        sceneload_EventChannel.OnLoadingScene -= LoadScene;
    }

    public void LoadScene(string moveSceneName)
    {
        StartCoroutine(LoadSceneCor(moveSceneName));
    }

    IEnumerator LoadSceneCor(string moveSceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(moveSceneName, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(curSceneName);
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfos[moveSceneName]);
        if(!curSceneName.Equals("Main")){
            player.transform.position = new Vector2(loadPlayerPos[curSceneName + moveSceneName].x, loadPlayerPos[curSceneName + moveSceneName].y);

            if (loadPlayerPos[curSceneName + moveSceneName].z >= 0.5)
            {
                player.GetComponent<SpriteRenderer>().flipX = true; // 오른쪽 바라봄
            } else if(loadPlayerPos[curSceneName + moveSceneName].z <= 0.1)
            {
                player.GetComponent<SpriteRenderer>().flipX = false; // 왼쪽 바라봄
            }
        }
        player.SetActive(true);
        curSceneName = moveSceneName;
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
        GlobalVariables.variables["playerName"].SetValue(playerDataSO.playerName);
    }
}
