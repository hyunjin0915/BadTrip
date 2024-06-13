using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SceneInfoSO")]
public class SceneInfoSO : ScriptableObject
{
    public bool isPlayer = true;
    public bool isDialog = true;

    public Vector2 playerPos = Vector2.zero;
}
