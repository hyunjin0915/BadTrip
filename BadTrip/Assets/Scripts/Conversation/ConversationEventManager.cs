using UnityEngine;
using Fungus;
using Cinemachine;
using System.Collections;

public class ConversationEventManager : MonoBehaviour
{
    // 대화창, 컷씬 이동, 퀘스트 관련 변수
    [SerializeField] private Character[] characters;
    [SerializeField] private SayDialogSO sayDialogSO;
    [SerializeField] private Transform[] viewTrs;
    [SerializeField] private CinemachineVirtualCamera conVCam;
    [SerializeField] private InteractionObjectsSO interactionObjectsSO;
    private GameObject playerVCam;

    // 사운드 관련 변수
    [SerializeField] private AudioCue audioCue;

    private void Start()
    {
        // 씬 내 캐릭터 및 대화창 초기화
        foreach (Character cha in characters)
        {
            int dialogType = cha.GetComponent<CharacterInfo>().dialogType;

            cha.SetSayDialog = sayDialogSO.dialogs[dialogType];
        }

    }

    #region Cutscene
    public void ShowCutscene(int viewNum) // 컷씬 이동
    {
        conVCam.Follow = viewTrs[viewNum];
        if (playerVCam == null)
        {
            playerVCam = GameObject.FindGameObjectWithTag("VCam");
            playerVCam.SetActive(false);
            conVCam.gameObject.SetActive(true);
        }
    }

    public void BackFromCutscene() // 컷씬에서 돌아옴
    {
        playerVCam.SetActive(true);
        conVCam.gameObject.SetActive(false);
        playerVCam = null;
    }
    #endregion

    #region Flowchart Call
    public void SendFlowchartMessage(string message) // 플로우차트 블록 메시지로 부르기
    {
        Fungus.Flowchart.BroadcastFungusMessage(message);
    }
    #endregion

    #region Player Animation Setting
    public void SetPlayerAnimLayer(int num) // Player 애니메이터 layer 설정
    {
        sayDialogSO.SetPlayerAnimLayer(num);
    }

    public void SetPlayerAnim(string boolName, bool b) // Player 애니메이션 설정
    {
        sayDialogSO.SetPlayerAnim(boolName, b);
    }
    #endregion

    #region Player Setting
    public void SetCanMove(bool b) // 플레이어 Move Control
    {
        StopPlayer();
        sayDialogSO.SetCanMove(b);
    }

    public void SetFootstepVolume(float v) // 플레이어 발소리 볼륨 조절
    {
        sayDialogSO.SetFootstepVolume(v);
    }

    public void SetPlayerPos(Vector2 pos, bool isFlip = false) // 플레이어 위치 설정
    {
        sayDialogSO.movePlayerPos(pos, isFlip); 
    }

    public void SetPlayerFlip(bool b)
    {
        sayDialogSO.SetPlayerFlip(b);
    }

    public void StopPlayer()
    {
        sayDialogSO.StopPlayer();
    }

    public void PlayerSetActive(bool b)
    {
        sayDialogSO.PlayerSetActive(b);
    }
    #endregion

    #region Scene Sound Setting
    public void PlayAudio(int num) // SFX 재생
    {
        audioCue.PlayAudio(num);
    }

    public void StopAudio(int num) // SFX 중지
    {
        audioCue.StopAudio(num);
    }
    #endregion

    #region QuestComplete
    public void CompleteQuest(int i = 1) // 퀘스트 종료(대화 끝에 사용)
    {
        interactionObjectsSO.CompleteConQuest(i);
    }

    public void UpdateQuest()
    {
        interactionObjectsSO.RaiseEvent();
    }
    #endregion

    public void SetSortingLayer(SpriteRenderer sp, string layer, int order) {
        sp.sortingLayerName = layer;
        sp.sortingOrder = order;
    }

    public void SetPlayerSortingLayer(string layer, int order)
    {
        sayDialogSO.SetPlayerSortingLayer(layer, order);
    }

    public void SetActiveMenuBg(bool b)
    {
        sayDialogSO.menuBackground.SetActive(b);
    }

    public void SetIsDialog(bool b)
    {
        sayDialogSO.SetIsDialog(b);
    }
}
