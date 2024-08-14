using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandControl : MonoBehaviour
{
    private Vector2 newPos;
    private float y;
    private bool isPlaying = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            y = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height * 0.45f);

            Cursor.SetCursor(null, new Vector2(Input.mousePosition.x, y), CursorMode.Auto);

            newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, y));

            transform.transform.position = newPos;
        }
    }

    public void SetIsPlaying(bool b)
    {
        isPlaying = b;
    }
    
    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
