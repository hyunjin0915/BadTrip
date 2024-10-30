using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CreateAssetMenu(menuName = "Conversation/SayDialogSO")]
public class SayDialogSO : ScriptableObject // Initialization 내용 중 맵 씬에서 사용될 것들
{
    public SayDialog[] dialogs;
    public Action<int> SetPlayerAnimLayer;
    public Action<string, bool> SetPlayerAnim;
    public Action<bool> SetCanMove, PlayerSetActive;
    public Action<float> SetFootstepVolume;
    public Action<Vector2, bool> movePlayerPos;
    public Action StopPlayer;
    public Action<string, int> SetPlayerSortingLayer;
    public GameObject menuBackground;
}
