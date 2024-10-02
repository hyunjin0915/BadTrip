using UnityEngine;

public class PlayerHDTrigger : MonoBehaviour
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
            if(collision.rigidbody.velocity.y<0 && transform.position.y < collision.transform.position.y)
            {
                Debug.Log("밟기!");
                transform.gameObject.SetActive(false);
            }
            else
            {
                Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
            }
            
        }
    }
}
