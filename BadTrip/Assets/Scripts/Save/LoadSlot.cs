using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadSlot : Slot, IPointerClickHandler
{
    private SaveManager saveManager;
    [SerializeField] private MapInteractionSetting mapInteractionSetting;
    [SerializeField] private MainUIManager mainUIManager;

    private JsonData data;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();

        string name = saveManager.GetPlayerName(slotNum);

        if (name != null)
        {
            SetPlayerName(name);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mainUIManager.PlayClickBtn();
        LoadData();
        GoScene();
    }

    public void LoadData()
    {
        data = saveManager.LoadData(slotNum);
    }

    public void GoScene()
    {
        if (data != null)
        {
            mapInteractionSetting.GoScene(data.sceneName);
        }
    }
}
