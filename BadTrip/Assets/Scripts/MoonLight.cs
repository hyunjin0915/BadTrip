using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoonLight : MonoBehaviour
{
    private Light2D moonlight;
    private bool isBrighting = true;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        moonlight = GetComponent<Light2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLighting();
        /*if(isBrighting)
        {
            StartCoroutine(UpdateBrighting());
            isBrighting = false;
        }
        else
        {
            StartCoroutine(UpdateDarkening());
            isBrighting = true;
        }*/
    }

    private void UpdateLighting()
    {
        moonlight.intensity = Mathf.PingPong(Time.time * speed, 2f);
    }
    private IEnumerator UpdateDarkening()
    {
        float f = 2f;
        while(f<2)
        {
            f -= speed;
            moonlight.intensity = f;
            yield return null;
        }
        
    }
    private IEnumerator UpdateBrighting()
    {
        float f = 0f;
        while(f<2)
        {
            f += speed;
            moonlight.intensity = f;
            yield return null;
        }
        
    }
}
