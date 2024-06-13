using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MonHP : MonoBehaviour
{
    public Image MonHPBar;
    [SerializeField]
    private MonsterHPSO Monster_healthManager;
    [SerializeField]
    private AudioCue audioCue;
    private void OnEnable()
    {
        MonsterHPSO.OnMonsterDamaged += ChangeHPBar;
        MonsterHPSO.PlaySound += audioCue.PlayAudio;
    }
    private void OnDisable()
    {
        MonsterHPSO.OnMonsterDamaged -= ChangeHPBar;
        MonsterHPSO.PlaySound -= audioCue.PlayAudio;
    }

    private void ChangeHPBar()
    {
        MonHPBar.fillAmount = Monster_healthManager.MonsterHealth/1000f;
    }

}
