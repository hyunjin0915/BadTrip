using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetting : MonoBehaviour
{
    [Header("Objects Setting")]
    public GameObject player;
    public GameObject dialogs;
    public GameObject audioListener;

    public void SetScene(SceneInfoSO sceneInfo)
    {
        player.SetActive(sceneInfo.isPlayer);
        dialogs.SetActive(sceneInfo.isDialog);
        audioListener.SetActive(!sceneInfo.isPlayer);

        player.transform.position = sceneInfo.playerPos;
    }

}
