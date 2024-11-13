using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    [SerializeField]
    private PlayerHPSO Player_healthManager;

    [SerializeField]
    GameObject player;
    [SerializeField]
    private float invincibilitytime;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SOPlayer"))
        {
            StartCoroutine(GetInvincibility());
            spriteRenderer.material.color = new Color (1, 1, 1, 0);
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    IEnumerator GetInvincibility()
    {
        Player_healthManager.isAttackable = false;
        yield return new WaitForSeconds(invincibilitytime);
        Player_healthManager.isAttackable = true;
    }
}
