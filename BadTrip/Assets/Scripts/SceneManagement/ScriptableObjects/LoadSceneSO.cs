using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Load Event Channel")]
public class LoadSceneSO : ScriptableObject
{
    // ºÒ·¯¿Ã ¾ÀÀÇ SceneInfoSO
    public SceneInfoSO loadSceneInfo;
    
    public event Action OnLoadingScene;

    public void RaiseEvent()
    {
        OnLoadingScene?.Invoke();
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
