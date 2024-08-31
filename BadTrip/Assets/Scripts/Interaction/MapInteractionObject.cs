using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapInteractionObject : MonoBehaviour
{
    public int interactionId;
    
    public UnityEvent interactionEvent;

    [SerializeField]
    private GameObject bang;


    public void OnInteraction()
    {
        interactionEvent.Invoke();
    }

    public void SetBang(bool b)
    {
        bang.SetActive(b);
    }
}
