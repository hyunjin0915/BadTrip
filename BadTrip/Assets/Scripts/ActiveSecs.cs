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
        eeee.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        dirInfo.SetActive(true);
    }

    private void ShowDirInfo()
    {
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            dirInfo.SetActive(false);
        }
    }
}
