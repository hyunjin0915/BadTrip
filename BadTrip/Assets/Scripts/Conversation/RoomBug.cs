using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBug : MonoBehaviour
{
    public GameObject[] bugs;
    public AudioCue audioCue;

    public void ActiveBugs()
    {
        StartCoroutine(activeBugs());
    }

    public IEnumerator activeBugs()
    {
        for (int i = 0; i < bugs.Length; i++)
        {
            audioCue.PlayAudio(3);
            bugs[i].SetActive(true);

            if (i < 3)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else if (i < 6)
            {
                yield return new WaitForSeconds(0.3f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void InactiveBugs()
    {
        foreach (GameObject bugs in bugs)
        {
            bugs.SetActive(false);
        }
    }
}
