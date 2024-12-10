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

    private GameObject player;
    private GameObject spawnPosition;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("SOPlayer");
        spawnPosition = player.transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            //other.gameObject.transform.position = spawnPosition.transform.position;
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
