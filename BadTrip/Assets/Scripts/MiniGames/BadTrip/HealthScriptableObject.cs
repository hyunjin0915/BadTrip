using System;
using UnityEngine;

[CreateAssetMenu( menuName ="ScriptableObject/Health")]
public class HealthScriptableObject : ScriptableObject
{
    public float PlayerHealth = 100f;
    public float MonsterHealth = 1000f;

    public static event Action OnPlayerDamaged;
    public static event Action OnMonsterDamaged;
    public void PlayerDecreaseHealth(float amount)
    {
        PlayerHealth -= amount;
        OnPlayerDamaged?.Invoke();

        if(PlayerHealth<=0) //플레이어 죽음
        {
            Debug.Log("게임 오버 이벤트 발생");
        }
    }
    public void MonsterDecreaseHealth(float amount)
    {
        MonsterHealth -= amount;
        OnMonsterDamaged?.Invoke();

        if(MonsterHealth<=0)//몬스터 죽음
        {
            
        }
    }

}
