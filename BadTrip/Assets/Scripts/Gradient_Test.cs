using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gradient_Test : MonoBehaviour
{
    public Gradient gradient;
    public Light2D headLight;
    // Start is called before the first frame update
    void Start()
    {
        headLight.color = gradient.Evaluate(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
