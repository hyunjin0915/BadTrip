using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMonster : MonoBehaviour
{
    public GameObject[] mons;
    public AudioCue audioCue;

    public void ActiveMons()
    {
        StartCoroutine(activeMons());
    }

    public IEnumerator activeMons()
    {
        foreach (GameObject mon in mons) {
            audioCue.PlayAudio(3);
            mon.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
