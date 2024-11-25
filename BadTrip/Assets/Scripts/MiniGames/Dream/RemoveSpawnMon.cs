using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveSpawnMon : MonoBehaviour
{
    [SerializeField]
    GameObject spawnMonsters;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            other.gameObject.SetActive(false);
        }
        else if(other.CompareTag("SOPlayer"))
        {
            spawnMonsters.SetActive(false);
        }
    }
}
