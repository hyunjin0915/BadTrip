using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 저장 클래스(Json으로 변환할 클래스)
[Serializable]
public class JsonData
{
    public string playerName;
    public int questId;
    public bool[] questPro;
    public string sceneName;
    public Vector2 playerPos;
    public int animLayer;
    public bool isflip;
}
