using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecreaseTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float helathDecreaseAmount = 10f;
    [SerializeField]
    private HealthScriptableObject healthManager;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌");
            healthManager.DecreaseHealth(helathDecreaseAmount);
        }
    }
}
