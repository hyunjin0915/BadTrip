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

    private IEnumerator coroutine;

    public int cntSpawn;

    // 스폰된 몬스터의 parent. <- 이거 설정 안하면 initialization에 몬스터가 생성되어서... StageOne, BadTrip을 벗어나도 ...몬스터가 존재해서 설정할게!
    [SerializeField] Transform monParent;
    
    private void Awake()
    {
        rangeCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        coroutine = RandomRespawn();
        cntSpawn = 3;
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        if(cntSpawn == 0) StopCoroutine(coroutine);
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
            yield return new WaitForSeconds(3f);

            GameObject instantMon = Instantiate(mudMon, GetRPos(), Quaternion.identity, monParent);
            yield return new WaitForSeconds(5f);
            GameObject instantMan = Instantiate(mudMan, GetRPos(), Quaternion.identity, monParent);
            cntSpawn--;
        }
    }
}
