using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRoom : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private ConversationEventManager conEventMng;
    [SerializeField] private Receivers receivers;

    // 퀘스트 관련 변수 // 후에 정리, 수정 필요
    [SerializeField] private GameObject mark;

    void Start()
    {
        if (playerData.eventNum == 0)
        {
            conEventMng.SetPlayerAnimLayer(1);
            // 플레이어 움직임, 플레이어 애니메이션 멈추기
            conEventMng.SetPlayerAnim("CanPMove", false);
        }
        else if (playerData.eventNum == 1)
        {
            mark.SetActive(false);
            receivers.SetReceiverActive(0, true);

        }
    }
}
