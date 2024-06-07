using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName ="ScriptableObject/Health/MonsterHPSO")]
public class MonsterHPSO : ScriptableObject
{
    public float MonsterHealth = 1000f;

    public static event Action OnMonsterDamaged;

    public void MonsterDecreaseHealth(float amount)
    {
        MonsterHealth -= amount;
        OnMonsterDamaged?.Invoke();

        if(MonsterHealth<=0)//몬스터 죽음
        {
            
        }
    }
}
