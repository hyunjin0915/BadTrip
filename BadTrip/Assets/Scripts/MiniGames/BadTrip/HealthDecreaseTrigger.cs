using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecreaseTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float helathDecreaseAmount = 10f;
    [SerializeField]
    private HealthScriptableObject healthManager;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthManager.DecreaseHealth(helathDecreaseAmount);
        }
    }
}
