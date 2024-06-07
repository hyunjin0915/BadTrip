using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName ="ScriptableObject/Health/PlayerHPSO")]
public class PlayerHPSO : ScriptableObject
{
    public float PlayerHealth = 100f;
    public static event Action OnPlayerDamaged;

    public void PlayerDecreaseHealth(float amount)
    {
        PlayerHealth -= amount;
        OnPlayerDamaged?.Invoke();

        if(PlayerHealth<=0) //플레이어 죽음
        {
            Debug.Log("게임 오버 이벤트 발생");
        }
    }
    
}
