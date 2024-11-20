using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotNum;

    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    public void SetPlayerName(string name)
    {
        textMeshProUGUI.text = name;
    }
}