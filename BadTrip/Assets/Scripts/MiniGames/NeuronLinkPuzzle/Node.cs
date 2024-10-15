using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler
{
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject topEdge;
    [SerializeField] private GameObject leftEdge;
    [SerializeField] private GameObject rightEdge;
    [SerializeField] private GameObject bottomEdge;
    [SerializeField] private GameObject highlight;

    public Dictionary<Node, GameObject> connectedEdges = new Dictionary<Node, GameObject>(); // 해당 노드의 이웃 노드들

    public int colorId;

    public bool isPoint = false;
    public bool isActive = false;

    public bool[] connectedEdgesIndex = new bool[4]; // 0 : up, 1 : down, 2 : left, 3 : right
    public Node[] connectedEdgesNodes = new Node[4]; // 0 : up, 1 : down, 2 : left, 3 : right

    public List<GameObject> connectedNodes = new List<GameObject>();

    public Vector2 pos2D { get; set; }

    [SerializeField] private NLPManager nlpManager;

    
    public void SetConnectedEdges(Vector2 offset, int index)
    {
        SetEdge(offset, connectedEdgesNodes[index]);
    }

    public void SetEdge(Vector2 offset, Node node)
    {
        if (offset == Vector2.up)
        {
            connectedEdges[node] = topEdge;
            return;
        }

        if (offset == Vector2.down)
        {
            connectedEdges[node] = bottomEdge;
            return;
        }

        if (offset == Vector2.right)
        {
            connectedEdges[node] = rightEdge;
            return;
        }

        if (offset == Vector2.left)
        {
            connectedEdges[node] = leftEdge;
            return;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPoint && !isActive)
        {
            nlpManager.isDragging = true;
            nlpManager.preNode = this;
            nlpManager.sourceNode = this;
            isActive = true;
            //nlpManager.curNode.connectedNodes.Add(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (nlpManager.isDragging)
        {
            nlpManager.isDragging = false;

            if (!nlpManager.preNode.isPoint)
            {
                nlpManager.sourceNode.ClearConnectedNodes();
            }

            nlpManager.preNode = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (nlpManager.isDragging && !isActive)
        {
            if (colorId != -1 && nlpManager.sourceNode.colorId != colorId)
            {
                nlpManager.sourceNode.isActive = false;
                return;
            }
            
            
            if (connectedEdges.ContainsKey(nlpManager.preNode))
            {
                connectedEdges[nlpManager.preNode].SetActive(true);
                connectedEdges[nlpManager.preNode].GetComponent<SpriteRenderer>().color = nlpManager.colors[nlpManager.sourceNode.colorId];
                nlpManager.sourceNode.connectedNodes.Add(connectedEdges[nlpManager.preNode]);
                nlpManager.preNode = this;
                isActive = true;
            }

            if (isPoint)
            {
                nlpManager.isDragging = false;
            }
        }
    }

    public void Init()
    {
        point.SetActive(false);
        topEdge.SetActive(false);
        leftEdge.SetActive(false);
        rightEdge.SetActive(false);
        bottomEdge.SetActive(false);
    }

    public void ClearConnectedNodes()
    {
        foreach (GameObject obj in connectedNodes)
        {
            obj.SetActive(false);
            obj.GetComponentInParent<Node>().isActive = false;
        }

        nlpManager.sourceNode.isActive = false;
    }
}
