using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsCtrl : MonoBehaviour
{
    Vector3 MoveV;
    Vector2 randomDir;
    int vec;
    public int speed;
    
    // Start is called before the first frame update
    void Awake()
    {
        speed = 5;
        vec = 1;
        Vector2 rDir = Random.insideUnitCircle.normalized;
        MoveV = new Vector3(rDir.x, rDir.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    private void Moving()
    {
        if(speed == 0) StartCoroutine(MoveAgainBug());
        transform.position += MoveV*Time.deltaTime * speed;
        Vector2 front = new Vector2(transform.position.x + vec*0.5f, transform.position.y);
        Debug.DrawRay(front, MoveV, new Color(0, 1, 0));
        RaycastHit2D rayHitBorder = Physics2D.Raycast(front, MoveV, 1, LayerMask.GetMask("Border"));
        if(rayHitBorder.collider != null)
        {
            ChangeDir();
        }
    }
    private void ChangeDir()
    {
        randomDir = Random.insideUnitCircle.normalized;
        MoveV.x = randomDir.x;
        MoveV.y = randomDir.y;
    }
    IEnumerator MoveAgainBug()
    {
        yield return new WaitForSeconds(5.0f);
        speed = 5;
    }
}
