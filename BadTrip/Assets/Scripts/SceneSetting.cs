using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetting : MonoBehaviour
{
    [Header("Objects Setting")]
    public GameObject player;
    public GameObject stplayer;
    public GameObject dialogs;
    public GameObject menuDialog;
    //public GameObject audioListener;
    public PlayerDataSO playerData;
    public SettingManager settingManager;

    public void SetScene(SceneInfoSO sceneInfo)
    {
        player.SetActive(sceneInfo.isPlayer);
        dialogs.SetActive(sceneInfo.isDialog);
        menuDialog.SetActive(sceneInfo.isDialog);
        //audioListener.SetActive(!sceneInfo.isPlayer);
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, sceneInfo.playerRen);
        //player.GetComponent<SpriteRenderer>().flipX = sceneInfo.isRight;
        player.GetComponent<Player>().SetAnimLayer(playerData.animLayer);
    }

}
