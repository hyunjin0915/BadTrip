using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteractionSetting : MonoBehaviour
{
    [SerializeField]
    private LoadSceneSOAll sceneload_EventChannel;

    public void GoScene(string moveSceneName)
    {
        sceneload_EventChannel.RaiseEvent(moveSceneName);
    }
}
