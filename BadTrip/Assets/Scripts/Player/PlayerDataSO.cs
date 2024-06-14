using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public string playerName;
    public bool isFemale;
    public bool isStudent;
    public int animLayer;

    public int eventNum;

    /*public void SetNameSex(string name, bool isF)
    {
        playerName = name;
        isFemale = isF;
    }*/
}
