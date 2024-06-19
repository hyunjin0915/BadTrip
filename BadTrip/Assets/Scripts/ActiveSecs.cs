using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveSecs : MonoBehaviour
{
    [SerializeField]
    private GameObject speechBubble;

    [SerializeField]
    private GameObject dirInfo;
    Renderer speechBubbleRenderer;
    Renderer dirInfoRenderer;

    [SerializeField]
    private ConversationEventManager conEvenMng;

    void Start()
    {
        StartCoroutine(ActiveForSeconds());
        speechBubbleRenderer = speechBubble.GetComponent<Renderer>();

    }
    void Update()
    {
        ShowDirInfo();
    }

    private IEnumerator ActiveForSeconds()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(speechBubbleFadeOut());
        yield return new WaitForSeconds(3.0f);
        dirInfo.SetActive(true);
        dirInfoRenderer = dirInfo.GetComponent<Renderer>();
        conEvenMng.SetPlayerAnim("CanPMove", true);

    }

    private void ShowDirInfo()
    {
        if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)) && dirInfo.activeSelf)
        {
            StartCoroutine(dirInfoFadeOut());
        }
        
    }

    private IEnumerator dirInfoFadeOut()
    {
        float f = 1;
        while(f>0)
        {
            f -= 0.01f;
            Color c  = dirInfoRenderer.material.color;
            c.a = f;
            dirInfoRenderer.material.color = c;
            yield return null;
        }
        dirInfo.SetActive(false);

    }
    private IEnumerator speechBubbleFadeOut()
    {
        float f = 1;
        while(f>0)
        {
            f -= 0.01f;
            Color c  = speechBubbleRenderer.material.color;
            c.a = f;
            speechBubbleRenderer.material.color = c;
            yield return null;
        }
        speechBubble.SetActive(false);

    }
}
