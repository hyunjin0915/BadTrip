using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHDTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float PlayerDamage = 10f;
    private Rigidbody2D myRigid;
    private PolygonCollider2D myCollider;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    public GameObject poping;
    [SerializeField]
    private PlayerHPSO Player_healthManager;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<PolygonCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SOPlayer"))
        {
            if(collision.rigidbody.velocity.y<0 && transform.position.y < collision.transform.position.y)
            {
                collision.rigidbody.AddForce(Vector2.up*150, ForceMode2D.Impulse);
                OnDamaged();
                poping.SetActive(true);
            }
            else
            {
                //animator.SetTrigger("Attack");
                Player_healthManager.PlayerDecreaseHealth(PlayerDamage);
            }
            
        }
    }

    private void OnDamaged()
    {
        if(myCollider!=null)
            myCollider.isTrigger = true;
        spriteRenderer.flipY = true;
        myRigid.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        Invoke("DeActive", 0.5f);
    }
    private void DeActive()
    {
        transform.gameObject.SetActive(false);
    }
}
