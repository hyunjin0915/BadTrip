using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, FirePos.transform.position,Quaternion.identity);
        }    
        
    }
}
