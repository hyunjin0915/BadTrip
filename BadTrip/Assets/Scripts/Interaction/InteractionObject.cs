using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConversationInteractionObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite exitSprite;
    [SerializeField] private Sprite enterSprite;

    [SerializeField] private AudioCue audioCue;
    [SerializeField] private int audioNum;

    public UnityEvent clickEvent;
    
    private void OnMouseEnter()
    {
        ChangeInteractionObjectSprite(enterSprite);
    }

    private void OnMouseExit()
    {
        ChangeInteractionObjectSprite(exitSprite);
    }

    private void OnMouseUp()
    {
        audioCue.PlayAudio(audioNum);
        clickEvent.Invoke();
    }

    public void ChangeInteractionObjectSprite(Sprite sprite)
    {
        sr.sprite = sprite;
    }
}
