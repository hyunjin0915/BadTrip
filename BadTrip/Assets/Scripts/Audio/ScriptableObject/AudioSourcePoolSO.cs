using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AudioSourcePoolSO")]
public class AudioSourcePoolSO : ScriptableObject
{
    public int asCount; // 맵에서 사용할 오디오 클립 오브젝트 개수

    public void DisableAS(AudioSource[] objects) // 오브젝트 비활성화
    {
        foreach (AudioSource ob in objects)
        {
            ob.gameObject.SetActive(false);
        }
    }

    public AudioSource EnableAS(AudioSource[] objects, int audioNum) // 오브젝트 활성화
    {
        objects[audioNum].gameObject.SetActive(true);
        return objects[audioNum];
    }
}
