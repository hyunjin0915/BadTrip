using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName ="Health")]
public class HealthScriptableObject : ScriptableObject
{
    public float health = 100f;

    public static event Action OnPlayerDamaged;

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();

        if(health<=0)
        {
            Debug.Log("게임 오버 이벤트 발생");
        }
    }
}
