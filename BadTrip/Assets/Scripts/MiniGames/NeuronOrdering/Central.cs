using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : MonoBehaviour
{
    public Transform InvisibleNeuron;
    List<Arranger> arrangers;

    // Start is called before the first frame update
    void Start()
    {
        arrangers = new List<Arranger>();

        var arrs = transform.GetComponentsInChildren<Arranger>();

        for(int i=0;i<arrs.Length;i++)
        {
            arrangers.Add(arrs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void SwapNeuron(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourIndex = sour.GetSiblingIndex();
        int destIndex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destIndex);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourIndex);

    }
    void SwapNeuronsInHierachy(Transform sour, Transform dest)
    {
        SwapNeuron(sour, dest);
        arrangers.ForEach(t=>t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt,pos);
    }
    void BeginDrag(Transform Neuron)
    {
        SwapNeuronsInHierachy(InvisibleNeuron, Neuron); //드래그 시작되면 바꿔주기
    }
    void Drag(Transform Neuron)
    {
        var whichArrangerNeuron = arrangers.Find(t => ContainPos(t.transform as RectTransform, Neuron.position));

        if(whichArrangerNeuron == null)
        {
            
        }
        else
        {
            int invisibleNeuronIndex = InvisibleNeuron.GetSiblingIndex();
            int targetIndex = whichArrangerNeuron.GetIndexByPosition(Neuron, invisibleNeuronIndex);

            if(invisibleNeuronIndex != targetIndex)
            {
                whichArrangerNeuron.SwapNeuron(invisibleNeuronIndex,targetIndex);
            }
            
        }
    }
    void EndDrag(Transform Neuron)
    {
        SwapNeuronsInHierachy(InvisibleNeuron, Neuron); //끝나면 순서 바꿔주고 정답 정렬인지 체크 
        if(arrangers[0].CheckOrder()) Debug.Log("순서 맞추기 성공");
    }
}
