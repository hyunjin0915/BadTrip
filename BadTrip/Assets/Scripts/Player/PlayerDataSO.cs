using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public string playerName;
    public int animLayer;
    public bool isFlip;
    public bool getDC = false;

    /*public void SetNameSex(string name, bool isF)
    {
        playerName = name;
        isFemale = isF;
    }*/
}
