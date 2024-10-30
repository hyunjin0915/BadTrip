using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class QuestBase
{
    public int questType; // 0 : 플레이어 상호작용하는 퀘스트 1 : 씬 이동하는 퀘스트 
    public bool isClear = false;
    public int interactionId; // 상호작용해야 하는 오브젝트 id
    public Player player;

    public abstract void QuestFunction();
}

[Serializable]
public class Quest_Interaction : QuestBase // 플레이어 상호작용하는 퀘스트
{
    public string message; // 펀거스 호출 메시지
    
    public override void QuestFunction()
    {
        Fungus.Flowchart.BroadcastFungusMessage(message);
        isClear = true;
        // 후에 추가
    }
}

[Serializable]
public class Quest_Move : QuestBase // 씬 이동하는 퀘스트
{
    public string message; // 펀거스 호출 메시지

    public override void QuestFunction() {
        Fungus.Flowchart.BroadcastFungusMessage(message);
    }
}

