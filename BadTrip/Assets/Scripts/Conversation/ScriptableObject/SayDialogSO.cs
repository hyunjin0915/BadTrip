using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CreateAssetMenu(menuName = "Conversation/SayDialogSO")]
public class SayDialogSO : ScriptableObject
{
    public SayDialog[] dialogs;
    public Action SetPlayerAnimLayer;
    public Action<string, bool> SetPlayerAnim;
    public Action<bool> SetCanMove;
}