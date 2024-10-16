using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerHDTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float PlayerDamage = 10f;
    private Rigidbody2D myRigid;

    [SerializeField]
    private PlayerHPSO Player_healthManager;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SOPlayer"))
        {
            Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
        }
    }
}
