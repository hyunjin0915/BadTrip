using UnityEngine;
using Fungus;
using Cinemachine;
using System.Collections;

public class ConversationEventManager : MonoBehaviour
{
    // 대화창, 씬 이동 관련 변수
    [SerializeField] private Character[] characters;
    [SerializeField] private SayDialogSO sayDialogSO;
    [SerializeField] private Transform[] viewTrs;
    [SerializeField] private CinemachineVirtualCamera conVCam;
    private GameObject playerVCam;

    // 플로우 차트 관련 변수
    [SerializeField] private Receivers receivers;
    private int fcIndex = 0;

    // 사운드 관련 변수
    [SerializeField] private AudioCue audioCue;

    private void Start()
    {
        foreach (Character cha in characters)
        {
            int dialogType = cha.GetComponent<CharacterInfo>().dialogType;

            cha.SetSayDialog = sayDialogSO.dialogs[dialogType];
        }

    }

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


    public void SendFlowchartMessage(int i, string message) // 플로우차트 블록 메시지로 부르기
    {
        receivers.SendFlowchartMessage(i, message);
    }

    public void SendFlowchartMessage(string message) // 플로우차트 블록 메시지로 부르기
    {
        receivers.SendFlowchartMessage(fcIndex, message);
    }

    public void SelectFlowchartIndex(int i)
    {
        fcIndex = i;
    }

    public void SetPlayerAnimLayer(int num)
    {
        sayDialogSO.SetPlayerAnimLayer(num);
    }

    public void SetPlayerAnim(string boolName, bool b)
    {
        sayDialogSO.SetPlayerAnim(boolName, b);
    }

    public void SetCanMove(bool b)
    {
        sayDialogSO.SetCanMove(b);
    }

    public void SetFootstepVolume(float v)
    {
        sayDialogSO.SetFootstepVolume(v);
    }

    public void PlayAudio(int num)
    {
        audioCue.PlayAudio(num);
    }

    public void StopAudio(int num)
    {
        audioCue.StopAudio(num);
    }
    
}
