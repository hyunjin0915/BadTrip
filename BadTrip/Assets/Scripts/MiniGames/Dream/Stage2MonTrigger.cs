using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stage2MonTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject stage2Monsters;
    private GameObject spawnMonsters;

    private bool isSpawn = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer") && !isSpawn)
        {
            spawnMonsters = Instantiate(stage2Monsters);
            isSpawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer") && isSpawn)
        {
            Destroy(spawnMonsters);
            isSpawn = false;
        }
    }
}
