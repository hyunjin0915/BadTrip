using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConversationManager : MonoBehaviour // ¸Ê ¾À°ú Initialization ¾À ¿¬°á
{
    [SerializeField] private SayDialog[] sayDialogs;

    [SerializeField] private SayDialogSO SayDialogSO;

    [SerializeField] private Player player;

    [SerializeField] private GameObject menuBackground;

    private void Awake()
    {
        SayDialogSO.dialogs = sayDialogs;
        SayDialogSO.menuBackground = menuBackground;
        SayDialogSO.SetPlayerAnimLayer += player.SetAnimLayer;
        SayDialogSO.SetPlayerAnim += player.SetPlayerAnim;
        SayDialogSO.SetCanMove += player.SetCanMove;
        SayDialogSO.SetFootstepVolume += player.SetFootstepVolume;
        SayDialogSO.movePlayerPos += player.SetPlayerPos;
        SayDialogSO.StopPlayer += player.StopPlayer;
        SayDialogSO.PlayerSetActive += player.PlayerSetActive;
        SayDialogSO.SetPlayerSortingLayer += player.SetSortingLayer;
    }

    private void OnDisable()
    {
        SayDialogSO.SetPlayerAnimLayer -= player.SetAnimLayer;
        SayDialogSO.SetPlayerAnim -= player.SetPlayerAnim;
        SayDialogSO.SetCanMove -= player.SetCanMove;
        SayDialogSO.SetFootstepVolume -= player.SetFootstepVolume;
        SayDialogSO.movePlayerPos -= player.SetPlayerPos;
        SayDialogSO.StopPlayer -= player.StopPlayer;
        SayDialogSO.PlayerSetActive -= player.PlayerSetActive;
        SayDialogSO.SetPlayerSortingLayer -= player.SetSortingLayer;
    }
}
