using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private SayDialog[] sayDialogs;

    [SerializeField] private SayDialogSO SayDialogSO;

    private void Awake()
    {
        SayDialogSO.dialogs = sayDialogs;
    }

}
