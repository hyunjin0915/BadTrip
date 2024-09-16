using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxClouds : MonoBehaviour
{
    [SerializeField][Range(-1.0f, 1.0f)]
    private float moveSpeed = 0.1f;
    private Material cloudMaterial;

    private void Awake()
    {
        cloudMaterial = GetComponent<Renderer>().material;
    }
    void Update()
    {
        cloudMaterial.SetTextureOffset("_MainTex", Vector2.right*moveSpeed*Time.time);
    }
}
