using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MovingMon
{
    protected override void Start()
    {
        base.Start();
    }
    
   void Update()
   {
        Move();
   }
}
