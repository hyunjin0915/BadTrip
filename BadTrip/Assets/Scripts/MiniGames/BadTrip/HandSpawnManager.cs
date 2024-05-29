using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpawnManager : MonoBehaviour
{
    public GameObject hand;
    private BoxCollider2D area;
    [Tooltip("attack delay time")]
    public float delayTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("SpawnHands",delayTime);
    }

    private IEnumerator SpawnHands(float delayTime)
    {
        Vector3 spawnPos = GetRandomPos();

        GameObject instance = Instantiate(hand, spawnPos,Quaternion.identity);
        area.enabled = false;
        yield return new WaitForSeconds(delayTime);

        area.enabled = true;
        StartCoroutine("SpawnHands", 20);
    }

    private Vector2 GetRandomPos()
    {
        Vector2 basePos = transform.position;
        Vector2 size = area.size;

        float posX = basePos.x + Random.Range(-size.x/2f, size.x/2f);
        float posY = basePos.y + Random.Range(-size.y/2f, size.y/2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
