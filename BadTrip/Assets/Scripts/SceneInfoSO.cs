using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SceneInfoSO")]
public class SceneInfoSO : ScriptableObject
{
    public bool isPlayer = true;
    public bool isDialog = true;
    /*public bool useReceiver = false;
    public string message;*/

    public int eventNum;

    public Vector2 playerPos = Vector2.zero;
}
