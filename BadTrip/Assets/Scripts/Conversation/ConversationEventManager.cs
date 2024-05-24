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
    [SerializeField] private MessageReceived receiver;

    // 환각 작용 관련 변수



    private void Start()
    {
        foreach (Character cha in characters)
        {
            int dialogType = cha.GetComponent<CharacterInfo>().dialogType;

            cha.SetSayDialog = sayDialogSO.dialogs[dialogType];
        }
    }

    public void OnHallucinationEffect() // 환각 효과 on
    {
        // 후에 내용 추가
        // 여기에 환각 작용 적용 내용 추가
        Debug.Log("환각 효과 ON");
    }

    public void OffHallucinationEffect() // 환각 효과 off
    {
        // 후에 내용 추가
        // 여기에 환각 작용 취소 내용 추가
        Debug.Log("환각 효과 OFF");
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


    public void SendFlowchartMessage(string message) // 플로우차트 블록 메시지로 부르기
    {
        receiver.OnSendFungusMessage(message);
    }
}
