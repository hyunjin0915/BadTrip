using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMethBug : MonoBehaviour
{
    public GameObject[] bugs;
    public AudioCue audioCue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AfterMethBug()
    {
        StartCoroutine(activeBugs());
    }

    public IEnumerator activeBugs()
    {
        for (int i = 0; i < bugs.Length; i++)
        {
            audioCue.PlayAudio(0);
            bugs[i].SetActive(true);

            if (i < 5)
            {
                yield return new WaitForSeconds(0.5f);
            } else if (i < 11)
            {
                yield return new WaitForSeconds(0.3f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
