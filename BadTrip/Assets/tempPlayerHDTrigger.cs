using System.Collections;
using Unity.Mathematics;
using UnityEditor;
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

    [SerializeField]
    private GameObject spawnPosition;
    Vector3 spawnPos;
    bool isSpawn = false;

    [SerializeField]
    private AudioCue audioCue;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        spawnPos.y = transform.position.y;
        spawnPos.z = transform.position.z;
        //Debug.Log(Vector2.right + Vector2.up);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SOPlayer"))
        {
            audioCue.PlayAudio(0);
            Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
            /*Vector2 direction = collision.gameObject.transform.position - transform.position;
            Debug.Log(direction);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, 1f)* bounceForce,ForceMode2D.Impulse);
            */
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("SOPlayer"))
        {
            if(!isSpawn)
                StartCoroutine(MonsterSpawnDelay());
        }
    }
    IEnumerator MonsterSpawnDelay()
    {
        isSpawn = true;
        yield return new WaitForSeconds(7f);
        spawnPos.x = spawnPosition.transform.position.x;
        Instantiate(this.gameObject,spawnPos,quaternion.identity, transform.parent);
    }
}
