using UnityEngine;

public class MonsterHDTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the Monster's health Decrease")]
    private float MonsterDamage = 1f;

    [SerializeField]
    private MonsterHPSO Monster_healthManager;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            Monster_healthManager.MonsterDecreaseHealth(MonsterDamage);
            Destroy(gameObject);
        }
    }
}
