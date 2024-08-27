using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapInteractionObject : MonoBehaviour
{
    public UnityEvent interactionEvent;


    public void OnInteraction()
    {
        interactionEvent.Invoke();
    }
}
