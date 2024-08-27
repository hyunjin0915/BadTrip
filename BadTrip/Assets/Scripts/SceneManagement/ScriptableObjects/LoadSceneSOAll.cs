using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Load Event Channel All")]
public class LoadSceneSOAll : ScriptableObject
{
    public event Action<string> OnLoadingScene;

    public void RaiseEvent(string moveSceneName)
    {
        OnLoadingScene?.Invoke(moveSceneName);
    }
}
