using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private SayDialog[] sayDialogs;

    [SerializeField] private SayDialogSO SayDialogSO;

    [SerializeField] private Player player;

    private void Awake()
    {
        SayDialogSO.dialogs = sayDialogs;
        SayDialogSO.SetPlayerAnimLayer += player.SetAnimLayer;
        SayDialogSO.SetPlayerAnim += player.SetPlayerAnim;
        SayDialogSO.SetCanMove += player.SetCanMove;
    }

}
