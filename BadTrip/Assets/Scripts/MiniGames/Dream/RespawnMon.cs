using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMon : MonoBehaviour
{
    [SerializeField]
    private GameObject rangeObject;
    [SerializeField]
    private GameObject mudMon;
    [SerializeField]
    private GameObject mudMan;
    BoxCollider2D rangeCollider;
    
    private void Awake()
    {
        rangeCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn());
    }
    
    Vector3 GetRPos()
    {
        Vector3 originPosition = rangeObject.transform.position;

        float range_X = rangeCollider.bounds.size.x;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0, 0);

        Vector3 respawnPosition =  originPosition + RandomPostion;
        return respawnPosition;
    }
    IEnumerator RandomRespawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f);

            GameObject instantMon = Instantiate(mudMon, GetRPos(), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            GameObject instantMan = Instantiate(mudMan, GetRPos(), Quaternion.identity);
        }
    }
}
