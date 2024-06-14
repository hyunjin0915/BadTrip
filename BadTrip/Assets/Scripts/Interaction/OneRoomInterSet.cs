using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRoomInterSet : MonoBehaviour
{
    [SerializeField] private LoadSceneSO toMethBugSL_EventChannel;

    public void GoMethBug()
    {
        toMethBugSL_EventChannel.RaiseEvent();
    }

}
