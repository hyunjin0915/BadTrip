using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBug : MonoBehaviour
{
    public bool isActive = true;
    public GameObject[] bugs;

    public void setIsActive(bool b)
    {
        isActive = b;
    }

    public void ActiveBugs()
    {
        StartCoroutine(activeBugs());
    }

    public IEnumerator activeBugs()
    {
        for (int i = 0; i < bugs.Length; i++)
        {
            
            bugs[i].SetActive(true);

            if (i < 1)
            {
                yield return new WaitForSeconds(0.4f);
            }
            else if (i < 3)
            {
                yield return new WaitForSeconds(0.25f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
