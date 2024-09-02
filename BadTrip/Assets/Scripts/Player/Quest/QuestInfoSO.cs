using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/QuestInfoSO")]
public class QuestInfoSO : ScriptableObject
{
    [TextArea(2, 8)]
    public string explain;
    
    public int questId;
    public string sceneName; // 퀘스트를 진행하는 씬 이름
    //public int[] objsId; // 상호작용 해야하는 오브젝트 아이디
    public int questCount; // 한 퀘스트 내 작은 여러 퀘스트가 있을 경우, 퀘스트 개수
    public int clearCount; // 클리어한 퀘스트 개수
    public bool isLast; // 순서가 있는 퀘스트인지. 순서가 있는 퀘스트의 경우 마지막 퀘스트만 클리어 하면 됨.

    public Quest_Interaction[] InterQuest;
    public Quest_Move[] moveQuests;

    public QuestBase[] allQuests;
}
