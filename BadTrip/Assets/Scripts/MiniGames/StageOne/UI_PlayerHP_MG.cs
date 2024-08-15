using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHP_MG : MonoBehaviour
{
    public PlayerHPSO Player_healthManager;
    public Image PlayerHPBar;
     private void OnEnable()
    {
        PlayerHPSO.OnPlayerDamaged +=ChangeHPBar;
    }
    private void OnDisable()
    {
        PlayerHPSO.OnPlayerDamaged -=ChangeHPBar;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeHPBar()
    {
        PlayerHPBar.fillAmount = Player_healthManager.PlayerHealth/Player_healthManager.PlayerMaxHealth;
    }
}
