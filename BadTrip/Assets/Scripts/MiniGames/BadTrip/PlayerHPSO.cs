using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu( menuName ="ScriptableObject/Health/PlayerHPSO")]
public class PlayerHPSO : ScriptableObject
{
    [SerializeField]

    public float PlayerHealth = 100f;
    public float PlayerMaxHealth = 100f;
    public bool isAttackable = true;
    
    public static event Action OnPlayerDamaged;
    public static event Action OnReStartGame;
    public void PlayerDecreaseHealth(float amount)
    {
        if(isAttackable)
        {
            PlayerHealth -= amount;
            OnPlayerDamaged?.Invoke();
        }
        if(PlayerHealth<=0 ) //플레이어 죽음(플레이어 죽고 위치 이동 전에 몬스터가 공격하면 fungus 이중으로 발생하여 isAttackable도 조건에 넣었습니다!)
        {
            isAttackable = false;
            Fungus.Flowchart.BroadcastFungusMessage("PlayerDead");
        }
    }
    public void PlayerHPInit()
    {
        PlayerHealth = PlayerMaxHealth;
        OnReStartGame?.Invoke();
        isAttackable = true;
    }
}
