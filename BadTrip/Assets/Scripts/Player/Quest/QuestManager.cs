using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private SceneMove sceneMove;

    [SerializeField]
    private List<QuestInfoSO> questSet; // 퀘스트 모음
    private Dictionary<int, QuestInfoSO> questDic = new Dictionary<int, QuestInfoSO>();

    public int curQuestId = 0;
    public QuestInfoSO info; // 현재 퀘스트 정보
    [SerializeField]
    private InteractionObjectsSO interactionObjects;

    [SerializeField]
    private PlayerDataSO playerDataSO;

    private void Start()
    {
        LoadAllQuestData();
        LoadQuest(curQuestId);
    }

    private void OnEnable()
    {
        interactionObjects.UpdateQuestScene += UpdateQuestState;
        interactionObjects.UpdateQuestScene += UpdateQuestScene;
        interactionObjects.CompleteQuest += CompleteQuest;
        
    }

    private void OnDisable()
    {
        interactionObjects.UpdateQuestScene -= UpdateQuestState;
        interactionObjects.UpdateQuestScene -= UpdateQuestScene;
        interactionObjects.CompleteQuest -= CompleteQuest;
    }

    private void LoadAllQuestData() // 게임 실행 시 처음 모든 퀘스트 데이터 사본을 만듦.
    {
        foreach (QuestInfoSO questInfo in questSet)
        {
            QuestInfoSO questinfoCopy = Instantiate(questInfo);

            List<QuestBase> allQuests = new List<QuestBase>();
            foreach (QuestBase questBase in questinfoCopy.moveQuests)
            {
                allQuests.Add(questBase);
            }
            foreach (QuestBase questBase in questinfoCopy.InterQuest)
            {
                allQuests.Add(questBase);
            }

            questinfoCopy.allQuests = allQuests.ToArray();

            questDic.Add(questInfo.questId, questinfoCopy);
        }
    }

    public void LoadQuest(int questId)
    {
        info = questDic[questId];

        UpdateQuestScene();
    }

    public void CompleteQuest()
    {
        curQuestId++;
        if (curQuestId < questSet.Count)
        {
            LoadQuest(curQuestId);
        }
    }

    public void UpdateQuestState(int? objId) // 퀘스트 상태 업데이트. 플레이어가 상호작용을 할 때 호출됨.
    {
        // 상호작용한 오브젝트 아이디 검사해서 체크
        for (int i = 0; i < info.allQuests.Length; i++)
        {
            if (objId == info.allQuests[i].interactionId && !info.allQuests[i].isClear)
            {
                // 상호작용 행동.
                info.allQuests[i].QuestFunction();
                info.clearCount++;
                Debug.Log("퀘스트 번호" + info.questId + " 퀘스트 클리어 개수"+ info.clearCount);
            }
        }

        // 모든 미니퀘스트가 클리어되면
        if ((info.isLast && info.allQuests[--info.questCount].isClear) || info.clearCount == info.questCount)
        {
            CompleteQuest();
        }
    }

    public void UpdateQuestState() // 퀘스트 상태 업데이트. 플레이어가 씬을 이동할 때 호출됨.
    {
        // 이동한 씬과 퀘스트 씬을 비교
        if (info == null)
        {
            return;
        }

        if (info.sceneName == sceneMove.curSceneName && info.allQuests[0].questType == 1 && !info.allQuests[0].isClear)
        {
            info.allQuests[0].QuestFunction();
            info.clearCount++;
        }

            // 모든 미니퀘스트가 클리어되면
        if ((info.isLast && info.allQuests[info.questCount -1].isClear) || info.clearCount == info.questCount)
        {
            CompleteQuest();
        }
    }

    public void UpdateQuestScene() // 씬 생성 시 처음 등 퀘스트 느낌표 업데이트
    {
        if (info == null)
        {
            return;
        }
        
        if (info.sceneName == sceneMove.curSceneName)
        {
            for (int i = 0; i < info.allQuests.Length; i++)
            {
                if (info.allQuests[i].questType == 0 && !info.allQuests[i].isClear)
                {
                    interactionObjects.interactionObjs[info.allQuests[i].interactionId]?.GetComponent<MapInteractionObject>().SetBang(true);
                }
            }
        }
    }

    public List<bool> GetQuestPro()
    {
        List<bool> pro = new List<bool>();

        foreach (QuestBase q in info.allQuests)
        {
            pro.Add(q.isClear);
        }

        return pro;
    }

    public void SetQuestPro(bool[] pro)
    {
        info = questDic[curQuestId];
        
        for (int i = 0; i < pro.Length; i++)
        {
            info.allQuests[i].isClear = pro[i];
        }
    }
}