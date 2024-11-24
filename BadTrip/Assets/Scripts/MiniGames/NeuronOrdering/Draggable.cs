using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    Transform root; //canvas를 넣어줌 - 부모에게 자신이 드래그 되고 있음을 알려줌
    // Start is called before the first frame update

    [SerializeField] private AudioCue audioCue;
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
        audioCue.PlayAudio(0);
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver); //자식 객체들에게 함수 실행 메세지 전송
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        root.BroadcastMessage("Drag",transform,SendMessageOptions.DontRequireReceiver);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag",transform,SendMessageOptions.DontRequireReceiver);
        audioCue.PlayAudio(0);
    }

    
}
