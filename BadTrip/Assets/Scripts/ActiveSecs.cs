using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveSecs : MonoBehaviour
{
    [SerializeField]
    private GameObject dirInfoSpace;
    [SerializeField]
    private GameObject dirInfo;
    Renderer dirInfoRenderer;

    void Start()
    {
        StartCoroutine(ActiveForSeconds());
    }
    void Update()
    {
        ShowDirInfo();
    }

    private IEnumerator ActiveForSeconds()
    {
        yield return new WaitForSeconds(3.0f);
        dirInfoSpace.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("실행");
        dirInfo.SetActive(true);
        dirInfoRenderer = dirInfo.GetComponent<Renderer>();
    }

    private void ShowDirInfo()
    {
        if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)) && dirInfo.activeSelf)
        {
            StartCoroutine(FadeOut());
        }
        
    }

    private IEnumerator FadeOut()
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
}
