using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{
    Rigidbody2D myRigid;
    [SerializeField]
    float bounceForce;
    [SerializeField]
    PlayerHPSO Player_healthManager;

    private void OnEnable()
    {
        PlayerHPSO.OnPlayerDamaged += bouncing;
    }
    private void OnDisable()
    {
        PlayerHPSO.OnPlayerDamaged -= bouncing;
    }

    private void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    private void bouncing()
    {
        myRigid.AddForce((Vector2.up+Vector2.right).normalized * bounceForce,ForceMode2D.Impulse);
    }
}
