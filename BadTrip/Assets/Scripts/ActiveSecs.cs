using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveSecs : MonoBehaviour
{
    [SerializeField]
    private GameObject eeee;
    [SerializeField]
    private GameObject dirInfo;
    Renderer dirInfoRenderer;

    void Start()
    {
        StartCoroutine(ActiveForSeconds());
        dirInfoRenderer = dirInfo.GetComponent<Renderer>();

    }
    void Update()
    {
        ShowDirInfo();
    }

    private IEnumerator ActiveForSeconds()
    {
        yield return new WaitForSeconds(3.0f);
        eeee.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        dirInfo.SetActive(true);
    }

    private void ShowDirInfo()
    {
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float f = 1;
        while(f>0)
        {
            f -= 0.1f;
            Color c  = dirInfoRenderer.material.color;
            c.a = f;
            dirInfoRenderer.material.color = c;
            yield return null;

        }
    }
}
