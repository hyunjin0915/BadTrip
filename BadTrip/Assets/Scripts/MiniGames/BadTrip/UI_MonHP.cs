using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MonHP : MonoBehaviour
{
    public Image MonHPBar;
    [SerializeField]
    private MonsterHPSO Monster_healthManager;
    private void OnEnable()
    {
        MonsterHPSO.OnMonsterDamaged += ChangeHPBar;
    }
    private void OnDisable()
    {
        MonsterHPSO.OnMonsterDamaged -= ChangeHPBar;
    }

    private void ChangeHPBar()
    {
        MonHPBar.fillAmount = Monster_healthManager.MonsterHealth/1000f;
    }

}
