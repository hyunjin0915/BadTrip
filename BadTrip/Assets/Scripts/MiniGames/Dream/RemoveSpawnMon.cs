using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveSpawnMon : MonoBehaviour
{
    [SerializeField]
    GameObject spawnMonsters;

    [SerializeField]
    private BossMonsterSound bms;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("SOPlayer"))
        {
            if (spawnMonsters != null) {
                bms.StopPlay();
                spawnMonsters.SetActive(false);
            }
        }
    }
}
