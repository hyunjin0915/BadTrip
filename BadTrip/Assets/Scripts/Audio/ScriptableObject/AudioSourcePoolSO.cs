using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AudioSourcePoolSO")]
public class AudioSourcePoolSO : ScriptableObject
{
    public void DisableAS(AudioSource[] objects) // 오브젝트 비활성화
    {
        foreach (AudioSource ob in objects)
        {
            ob.Stop();
        }
    }
}
