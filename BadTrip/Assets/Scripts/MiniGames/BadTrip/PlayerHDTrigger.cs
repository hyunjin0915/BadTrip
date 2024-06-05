using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHDTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float PlayerDamage = 10f;

    [SerializeField]
    private HealthScriptableObject Player_healthManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
        }
    }
}
