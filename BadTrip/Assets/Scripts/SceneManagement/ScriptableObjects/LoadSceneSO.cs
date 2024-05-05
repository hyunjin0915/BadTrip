using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Load Event Channel")]
public class LoadSceneSO : ScriptableObject
{
    public event Action OnLoadingScene;

    public void RaiseEvent()
    {
        OnLoadingScene?.Invoke();
    }
}
