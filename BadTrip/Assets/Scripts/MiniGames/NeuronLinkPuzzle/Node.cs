using Fungus.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject point;
    public GameObject[] horizonEdge; // 가로 이미지
    public GameObject[] verticalEdge; // 세로 이미지
    public GameObject[] uprightEdge;
    public GameObject[] upleftEdge;
    public GameObject[] bottomrightEdge;
    public GameObject[] bottomleftEdge;
    public GameObject[] highlight;

    public Edge pre = Edge.none; // 이전 노드
    
    public Dictionary<Node, Edge> connectedEdges = new Dictionary<Node, Edge>(); // 해당 노드의 이웃 노드들

    public int colorId;

    public bool isPoint = false;
    public bool isActive = false;

    public bool[] connectedEdgesIndex = new bool[4]; // 0 : up, 1 : down, 2 : left, 3 : right
    public Node[] connectedEdgesNodes = new Node[4]; // 0 : up, 1 : down, 2 : left, 3 : right

    public int nodeNum;

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
            connectedEdges[node] = Edge.up;
            return;
        }

        if (offset == Vector2.down)
        {
            connectedEdges[node] = Edge.down;
            return;
        }

        if (offset == Vector2.right)
        {
            connectedEdges[node] = Edge.right;
            return;
        }

        if (offset == Vector2.left)
        {
            connectedEdges[node] = Edge.left;
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
            highlight[nlpManager.sourceNode.colorId].SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (nlpManager.isDragging)
        {
            nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1].GetComponentInParent<Node>().highlight[nlpManager.sourceNode.colorId].SetActive(false);

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
                highlight[nlpManager.sourceNode.colorId].SetActive(true);

                // 이전 노드 설정
                if (nlpManager.preNode.pre != Edge.none)
                {
                    CheckPreNode(nlpManager.sourceNode.colorId);
                }

                if (!isPoint)
                {
                    CheckNode(nlpManager.sourceNode.colorId, nlpManager.preNode);

                }

                nlpManager.nodeCount++;
                nlpManager.preNode = this;
                isActive = true;
            }

            if (isPoint && nlpManager.sourceNode != this) // 성공
            {
                nlpManager.isDragging = false;
                highlight[nlpManager.sourceNode.colorId].SetActive(false);

                nlpManager.addSuccessCount();
                nlpManager.CheckSuccesse();
            }

        }

        if (nlpManager.isDragging && isActive) // 이전에 왔던 곳
        {
            if (connectedEdges.ContainsKey(nlpManager.preNode))
            {
                highlight[nlpManager.sourceNode.colorId].SetActive(true);

                if (nlpManager.nodeCount > 1)
                {
                    if (nodeNum == nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 2]?.GetComponentInParent<Node>().nodeNum)
                    {
                        nlpManager.preNode.GetComponentInParent<Node>().isActive = false;
                        nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1].SetActive(false);
                        nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 2].SetActive(false);

                        if (nlpManager.nodeCount - 3 < 0) 
                        {
                            nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 2].GetComponentInParent<Node>().CheckNode(nlpManager.sourceNode.colorId, nlpManager.sourceNode);
                        } else
                        {
                            nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 2].GetComponentInParent<Node>().CheckNode(nlpManager.sourceNode.colorId, nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 3].GetComponentInParent<Node>());
                        }

                        nlpManager.sourceNode.connectedNodes.RemoveAt(nlpManager.nodeCount - 1);
                        nlpManager.sourceNode.connectedNodes.RemoveAt(nlpManager.nodeCount - 2);
                        nlpManager.nodeCount--;
                        nlpManager.preNode = this;
                    }
                }
                else if (nlpManager.nodeCount == 1) 
                {
                    nlpManager.preNode.GetComponentInParent<Node>().isActive = false;
                    nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1].SetActive(false);
                    nlpManager.sourceNode.connectedNodes.RemoveAt(nlpManager.nodeCount - 1);
                    nlpManager.nodeCount--;
                    nlpManager.preNode = this;
                }
            }
            else if(nlpManager.preNode.Equals(this))
            {
                highlight[nlpManager.sourceNode.colorId].SetActive(true);
            }
        }
    }

    public void Init()
    {
        //point.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            verticalEdge[i].SetActive(false);
            horizonEdge[i].SetActive(false);
            uprightEdge[i].SetActive(false);
            upleftEdge[i].SetActive(false);
            bottomleftEdge[i].SetActive(false);
            bottomrightEdge[i].SetActive(false);
        }

        isActive = false;
    }

    public void ClearConnectedNodes()
    {
        for (int i = 0; i < connectedNodes.Count; i++)
        {
            connectedNodes[i].SetActive(false);
            connectedNodes[i].GetComponentInParent<Node>().isActive = false;
        }

        connectedNodes.Clear();

        isActive = false;
        nlpManager.nodeCount = 0;
    }

    public void CheckPreNode(int i)
    {
        Edge preEdge = nlpManager.preNode.pre;
        Edge curEdge = nlpManager.preNode.connectedEdges[this];

        string edges = preEdge.ToString() + curEdge.ToString();

        nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1].SetActive(false);

        switch (edges)
        {
            case "updown":
            case "downup":
                nlpManager.preNode.verticalEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1] = nlpManager.preNode.verticalEdge[i];
                // 세로 이미지 active
                break;
            case "leftright":
            case "rightleft":
                nlpManager.preNode.horizonEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1] = nlpManager.preNode.horizonEdge[i];
                // 가로 이미지 active
                break;
            case "upleft":
            case "leftup":
                nlpManager.preNode.upleftEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1] = nlpManager.preNode.upleftEdge[i];
                // 위왼쪽 이미지 active
                break;
            case "upright":
            case "rightup":
                nlpManager.preNode.uprightEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1] = nlpManager.preNode.uprightEdge[i];
                // 위오른쪽 이미지 active
                break;
            case "downleft":
            case "leftdown":
                nlpManager.preNode.bottomleftEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1] = nlpManager.preNode.bottomleftEdge[i];
                // 왼쪽아래 이미지 active
                break;
            case "downright":
            case "rightdown":
                nlpManager.preNode.bottomrightEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes[nlpManager.nodeCount - 1] = nlpManager.preNode.bottomrightEdge[i];
                // 오른쪽 아래 이미지 active
                break;
            default:
                break;
        }
        
    }

    public void CheckNode(int i, Node n)
    {
        pre = connectedEdges[n];

        switch (pre)
        {
            case Edge.up:
            case Edge.down:
                verticalEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes.Add(verticalEdge[i]);
                // 세로
                break;
            case Edge.left:
            case Edge.right:
                horizonEdge[i].SetActive(true);
                nlpManager.sourceNode.connectedNodes.Add(horizonEdge[i]);
                // 가로
                break;
            default:
                break;

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (nlpManager.isDragging)
        {
            highlight[nlpManager.sourceNode.colorId].SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPoint)
        {
            highlight[colorId].SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPoint)
        {
            highlight[colorId].SetActive(false);
        }
    }
}
