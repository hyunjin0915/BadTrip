using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHDTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("How much should the player's health Decrease")]
    private float PlayerDamage = 10f;
    private float scaleX;
    private float scaleY;

    private Rigidbody2D myRigid;
    private PolygonCollider2D myCollider;
    SpriteRenderer spriteRenderer;


    public GameObject poping;
    [SerializeField]
    private PlayerHPSO Player_healthManager;

    [SerializeField]
    private AudioCue audioCue;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<PolygonCollider2D>();

        scaleX = gameObject.transform.localScale.x;
        scaleY = gameObject.transform.localScale.y;
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
        //spriteRenderer.flipY = true;
        myRigid.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        audioCue.PlayAudio(1);
        StartCoroutine(MonsterFadeOut());
        //Invoke("DeActive", 0.5f);
    }

    private IEnumerator MonsterFadeOut()
    {
        float f = 1;
        float sxf = (scaleX<0)?-0.003f:0.003f;
        float syf = 0.003f;
        while(f>0)
        {
            f -= 0.02f;
            scaleX += sxf;
            scaleY += syf;

            Color c  = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;

            transform.localScale = new Vector3(scaleX, scaleY,1);

            yield return null;
        }
        gameObject.SetActive(false);

    }
    private void DeActive()
    {
        transform.gameObject.SetActive(false);
    }


}
