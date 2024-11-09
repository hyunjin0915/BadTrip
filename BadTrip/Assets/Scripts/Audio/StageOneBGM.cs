using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class StageOneBGM : MonoBehaviour
{
    [SerializeField] private BGMPlay BGMPlay;

    public int stageNum;
    public bool startPlaying;
    public float fade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("SOPlayer"))
        {
            if (startPlaying)
            {
                BGMPlay.OnlyPlayBGM(stageNum, fade);
            } else
            {
                BGMPlay.StopBGM(fade);
            }

            gameObject.SetActive(false);
        }
    }
}
