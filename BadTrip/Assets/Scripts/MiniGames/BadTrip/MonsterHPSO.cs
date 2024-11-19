using System;
using UnityEngine;

[CreateAssetMenu( menuName ="ScriptableObject/Health/MonsterHPSO")]
public class MonsterHPSO : ScriptableObject
{
    public float MonsterHealth = 1000f;
    public float MonsterMaxHealth = 1000f;

    public static event Action OnMonsterDamaged;
    public static event Action<int> PlaySound; 

    public void MonsterDecreaseHealth(float amount)
    {
        PlaySound?.Invoke(1);

        MonsterHealth -= amount;
        OnMonsterDamaged?.Invoke();

        if(MonsterHealth<=0)//몬스터 죽음
        {
            Fungus.Flowchart.BroadcastFungusMessage("DevilDead");
        }
    }
}
