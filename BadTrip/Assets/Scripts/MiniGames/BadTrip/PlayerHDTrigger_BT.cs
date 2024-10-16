using UnityEngine;

public class PlayerHDTrigger_BT : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BTPlayer"))
        {
            Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BTPlayer"))
        {
            Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
        }
    }
}
