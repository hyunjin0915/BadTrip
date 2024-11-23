using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private PlayerHPSO Player_healthManager;
    [SerializeField]
    private float PlayerDamage = 5f;
    [SerializeField]
    private float invincibilitytime;
    [SerializeField]
    private float flickerTime;
    [SerializeField]
    private GameObject player;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("SOPlayer"))
        {
            Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
            StartCoroutine(GetInvincibility());
            StartCoroutine(GetFlicker());
        }

    }
    IEnumerator GetInvincibility()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        Player_healthManager.isAttackable = false;
        yield return new WaitForSeconds(invincibilitytime);
        Player_healthManager.isAttackable = true;
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        yield return null;
    }

    IEnumerator GetFlicker()
    {
        while(!Player_healthManager.isAttackable)
        {
            Debug.Log("flicker");
            spriteRenderer.material.color = new Color (1, 1, 1, 0.2f);
            yield return new WaitForSeconds(flickerTime);
            spriteRenderer.material.color = new Color (1, 1, 1, 1);
            yield return new WaitForSeconds(flickerTime);
        }
    }
}
