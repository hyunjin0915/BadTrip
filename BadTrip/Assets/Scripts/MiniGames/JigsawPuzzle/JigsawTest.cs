using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawTest : MonoBehaviour
{
    [SerializeField]
    List<Transform> puzzles = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform puzzle in puzzles)
        {
            Transform targetPosition = puzzle.GetComponent<TargetPos>().targetPosition;
            puzzle.position = targetPosition.position;
            puzzle.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
