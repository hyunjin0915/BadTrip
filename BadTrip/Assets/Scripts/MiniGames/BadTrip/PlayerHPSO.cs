using System;
using UnityEngine;

[CreateAssetMenu( menuName ="ScriptableObject/Health/PlayerHPSO")]
public class PlayerHPSO : ScriptableObject
{
    [SerializeField]

    public float PlayerHealth = 100f;
    public float PlayerMaxHealth = 100f;
    public bool isAttackable = true;
    
    public static event Action OnPlayerDamaged;

    public void PlayerDecreaseHealth(float amount)
    {
        if(isAttackable)
        {
            PlayerHealth -= amount;
            OnPlayerDamaged?.Invoke();
        }
        if(PlayerHealth<=0) //플레이어 죽음
        {
            
            Debug.Log("게임 오버 이벤트 발생");

            Fungus.Flowchart.BroadcastFungusMessage("PlayerDead");
        }
    }

    public void PlayerHPInit()
    {
        PlayerHealth = PlayerMaxHealth;
    }
    
}
