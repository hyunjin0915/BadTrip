using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerHDTrigger : MonoBehaviour
{
    //stage3 몬스터들에만 들어가는 스크립트 

    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float PlayerDamage = 10f;
    private Rigidbody2D myRigid;

    [SerializeField]
    float bounceForce=100f;

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

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 ,0.3f) * bounceForce,ForceMode2D.Impulse);
        }
    }
}
