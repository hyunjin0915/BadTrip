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

    [SerializeField] private SettingManager settingManager;

    [SerializeField] private AudioManager audioManager;

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
        SayDialogSO.SetIsDialog += settingManager.SetIsDialog;
        SayDialogSO.SetPlayerFlip += player.SetPlayerFlip;
        SayDialogSO.SetCanChangeBGM += audioManager.SetCanChangeBGM;

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
        SayDialogSO.SetIsDialog -= settingManager.SetIsDialog;
        SayDialogSO.SetPlayerFlip -= player.SetPlayerFlip;
        SayDialogSO.SetCanChangeBGM -= audioManager.SetCanChangeBGM;
    }
}
