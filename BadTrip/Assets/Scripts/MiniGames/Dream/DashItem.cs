using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashItem : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashSpeed;

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer"))
        {
            StartCoroutine(SetDashSpeed());
            spriteRenderer.material.color = new Color (1, 1, 1, 0);
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    IEnumerator SetDashSpeed()
    {
        player.GetComponent<PlayerMove>().walkSpeed += dashSpeed;
        yield return new WaitForSeconds(dashTime);
        player.GetComponent<PlayerMove>().walkSpeed -= dashSpeed;
    }
}
