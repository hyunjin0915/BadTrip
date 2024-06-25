using System.Collections;
using UnityEngine;

public class CatchBugs : MonoBehaviour
{
    GameObject hitBug;
    void Update()
    {
        Catching();
    }

    private void Catching()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 1.0f);

            if(hit.collider != null)
            {
                hitBug = hit.transform.gameObject;
                if(hitBug.CompareTag("Bug"))
                {
                    if(hitBug.GetComponent<BugsCtrl>().speed == 0)
                    {
                        hitBug.SetActive(false);
                    }
                    else
                    {
                        hitBug.GetComponent<BugsCtrl>().speed = 0;
                        StartCoroutine(MoveAgainBug());
                    }
                }
            }
        }
    }
    public IEnumerator MoveAgainBug()
    {
        yield return new WaitForSeconds(5.0f);
        hitBug.GetComponent<BugsCtrl>().speed  = 5;
    }
}
