using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MovingMon
{
    void Start()
    {
        currentPosition = transform.position; //현재 위치의 x값 저장.
        currentScaleX = transform.localScale.x;	//현재 스케일의 x값 저장.
        currentScaleY = transform.localScale.y;	//현재 스케일의 x값 저장.

        rightMax_Apply = currentPosition.x+rightMax;
        leftMax_Apply = currentPosition.x + leftMax;
    }
   void Update()
   {
        Move();
   }
}
