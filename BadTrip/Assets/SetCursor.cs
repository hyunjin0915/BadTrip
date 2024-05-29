using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorNormal;
    [SerializeField] Texture2D cursorHover;

    private Vector2 cursorCenter;

    // Start is called before the first frame update
    void Start()
    {
        cursorCenter.x = cursorNormal.width/2;
        cursorCenter.y = cursorNormal.height/2;

        Cursor.SetCursor(cursorNormal, cursorCenter, CursorMode.Auto);
    }
    public void OnMouseUp()
    {
        Cursor.SetCursor(cursorHover, cursorCenter, CursorMode.Auto);
    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(cursorNormal, cursorCenter, CursorMode.Auto);
    }
}
