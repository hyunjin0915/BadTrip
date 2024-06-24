using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Receivers : MonoBehaviour
{
    [SerializeField] private MessageReceived[] mReceivers;

    public void SetReceiverActive(int i, bool b)
    {
        mReceivers[i].gameObject.SetActive(b);
    }

    public void SendFlowchartMessage(int i, string message)
    {
        mReceivers[i]?.OnSendFungusMessage(message);
    }
}
