using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Edge
{
    none,
    up,
    down,
    left,
    right
}

public class NLPManager : MonoBehaviour
{
    private List<Vector2> offsetPos = new List<Vector2>()
    { Vector2.up, Vector2.down, Vector2.left, Vector2.right};
    public Node[] nodes;

    public Color[] colors;


    public bool isDragging = false;
    public Node sourceNode; // 시작 노드
    public Node preNode; // 이전 노드

    public int nodeCount = 0;

    public int successCount = 0;

    private void Start()
    {
        SetAllNodes();
    }


    private void SetAllNodes()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (nodes[i].connectedEdgesIndex[j])
                {
                    nodes[i].SetConnectedEdges(offsetPos[j], j);
                }
            }
        }    
    }

    public void addSuccessCount()
    {
        successCount++;
        nodeCount = 0;
        Debug.Log ("하나 성공");
    }
    
    public void CheckSuccesse()
    {
        if (successCount >= 5)
        {
            // 완전 성공
            // 게임 클리어시 실행 부분 추가
        }
    }

    public void Reset()
    {
        foreach (Node node in nodes) {
            node.Init();
            node.ClearConnectedNodes();
        }
    }
}
