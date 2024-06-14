using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FireBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;

    [SerializeField] private AudioCue audioCue;

    public bool gameStart = true;


    // Update is called once per frame
    void Update()
    {
        gameStart = FungusManager.Instance.GlobalVariables.GetVariable("gameStart");

        
            if(Input.GetKeyDown(KeyCode.Space))
            {
                audioCue.PlayAudio(0);
                Instantiate(Bullet, FirePos.transform.position,Quaternion.identity);
            }    
        
        
    }
}
