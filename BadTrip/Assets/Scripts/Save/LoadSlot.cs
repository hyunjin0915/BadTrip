using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadSlot : MonoBehaviour, IPointerClickHandler
{
    public int slotNum;
    
    private SaveManager saveManager;
    [SerializeField] private MapInteractionSetting mapInteractionSetting;
    [SerializeField] private MainUIManager mainUIManager;

    private JsonData data;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
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
        mapInteractionSetting.GoScene(data.sceneName);
    }
}
