using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/InteractionObjectsSO")]
public class InteractionObjectsSO : ScriptableObject
{
    public Dictionary<int, GameObject> interactionObjs = new Dictionary<int, GameObject>();

    public event Action UpdateQuestScene;
    public event Action CompleteQuest;

    public void RaiseEvent()
    {
        UpdateQuestScene?.Invoke();
    }

    public void CompleteConQuest()
    {
        CompleteQuest?.Invoke();
    }
}
