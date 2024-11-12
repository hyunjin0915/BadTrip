using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleyLight : MonoBehaviour
{
    [SerializeField] ConversationEventManager conversationEventManager;

    public SpriteRenderer alleySP;
    public Sprite day;
    public Sprite night;
    public GameObject lights;
    
    // Start is called before the first frame update
    void Start()
    {
        // 퀘스트 번호에 따라 달라짐.

        if (conversationEventManager.GetCurQuestNum() <= 14)
        {
            alleySP.sprite = night;
            lights.SetActive(true);
        } else
        {
            alleySP.sprite = day;
            lights.SetActive(false);
        }
    }

    
}
