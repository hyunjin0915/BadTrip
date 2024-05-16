using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConTest : MonoBehaviour
{

    [SerializeField] private Flowchart flowchart;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(flowchart.GetStringVariable("playerName"));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
