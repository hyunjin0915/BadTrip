using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    Transform root; //canvas를 넣어줌 - 부모에게 자신이 드래그 되고 있음을 알려줌
    // Start is called before the first frame update
    void Start()
    {
        root = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        root.BroadcastMessage("Drag",transform,SendMessageOptions.DontRequireReceiver);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag",transform,SendMessageOptions.DontRequireReceiver);
    }

    
}
