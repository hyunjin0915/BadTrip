using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    List<Transform> children;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>(); //하나의 arranger 아래의 뉴런들
        UpdateChildren();  
    }

    public void UpdateChildren()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            if(i == children.Count)
            {
                children.Add(null); //사이즈 작으면 늘리기
            }

            var child = transform.GetChild(i);

            if(child != children[i])
            {
                children[i]=child;
            }
        }
        children.RemoveRange(transform.childCount,children.Count - transform.childCount); //개수유지 
    }
    public bool CheckOrder()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            if(transform.GetChild(i).name != ("Neuron"+i))
            {
                return false;
            }
        }
        return true;
    }
    public int GetIndexByPosition(Transform neuron, int skipIndex = -1)
    {
        int result = 0;
        for(int i=0;i<children.Count;i++)
        {
            if(neuron.position.x < children[i].position.x)
            {
                break;
            }
            else if(skipIndex != i)
            {
                result++;
            }
        }
        return result;
    }

    public void SwapNeuron(int index01, int index02)
    {
        Central.SwapNeuron(children[index01], children[index02]);
        UpdateChildren();
    }

}
