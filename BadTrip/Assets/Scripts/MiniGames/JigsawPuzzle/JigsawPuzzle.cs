using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JigsawPuzzle : MonoBehaviour
{
    Vector3 offset;
   
    private Transform draggingPiece = null;

    int answer;

    [SerializeField]
    List<Transform> puzzles = new List<Transform>();
    private List <SpriteRenderer> puzzleSpriteRenderers = new List<SpriteRenderer>();
    
    // Start is called before the first frame update
    void Start()
    {
        answer = 0;
        foreach(Transform puzzle in puzzles)
        {
            puzzleSpriteRenderers.Add(puzzle.GetComponent<SpriteRenderer>());
        }
        Debug.Log(puzzleSpriteRenderers[0].name);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit)
            {
                draggingPiece = hit.transform;
                  
                offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //offset += Vector3.back;
            }
        }

        if(draggingPiece && Input.GetMouseButtonUp(0))
        {
            draggingPiece.position += Vector3.forward;
            SnapAndDisableIfCorrect();
            draggingPiece = null;

        }

        if(draggingPiece)
        {
            Vector3 newPosiotion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosiotion+=offset;
            foreach(Transform puzzle in puzzles)
            {
                if(puzzle.Equals(draggingPiece))
                {
                    puzzle.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
                else puzzle.GetComponent<SpriteRenderer>().sortingOrder = 0;
            } 
            draggingPiece.position = newPosiotion;
        }
    }

    private void SnapAndDisableIfCorrect()
    {
        Transform targetPosition = draggingPiece.GetComponent<TargetPos>().targetPosition;
        
        if(targetPosition!=null && Vector2.Distance(draggingPiece.position, targetPosition.position) < 1f)
        {
            draggingPiece.position = targetPosition.position;
            //Debug.Log(targetPosition.position);
            draggingPiece.GetComponent<BoxCollider2D>().enabled = false;
            answer++;
            if(answer==25) 
            {
                Debug.Log("게임 클리어 이벤트 발생");
            }
        }
    }

}
