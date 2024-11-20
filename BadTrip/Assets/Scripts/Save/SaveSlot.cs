using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveSlot : Slot, IPointerClickHandler
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private GameObject checkSave;
    [SerializeField] private Button saveBtn;
    
    void Start()
    {
        string name = saveManager.GetPlayerName(slotNum);

        if (name != null)
        {
            SetPlayerName(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        saveBtn.onClick.RemoveAllListeners();
        saveBtn.onClick.AddListener(SaveData);
        
        checkSave.SetActive(true);
    }

    public void SaveData()
    {
        saveManager.SaveData(slotNum);
        SetPlayerName(saveManager.GetPlayerName(slotNum));
    }
}
