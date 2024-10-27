using UnityEngine;

public class MonsterHDTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the Monster's health Decrease")]
    private float MonsterDamage = 1f;

    [SerializeField]
    private MonsterHPSO Monster_healthManager;
    [SerializeField]
    private PlayerDataSO playerDataSO;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            if (playerDataSO.getDC)
            {
                MonsterDamage = 100;
            }
            
            Monster_healthManager.MonsterDecreaseHealth(MonsterDamage);
            Destroy(gameObject);
        }
    }
}
