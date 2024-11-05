using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/InteractionObjectsSO")]
public class InteractionObjectsSO : ScriptableObject
{
    public Dictionary<int, GameObject> interactionObjs = new Dictionary<int, GameObject>();

    public event Action UpdateQuestScene;
    public event Action<int> CompleteQuest;

    public void RaiseEvent()
    {
        UpdateQuestScene?.Invoke();
    }

    public void CompleteConQuest(int i = 1)
    {
        CompleteQuest?.Invoke(i);
    }
}
