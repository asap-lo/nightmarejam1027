using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D menuCursor;

    public Texture2D otherCursor;
 
    // Update is called once per frame
    void Update()
    {

    }

    void SetmenuCursor()
    {
        Vector2 hotspot = new Vector2(menuCursor.width / 2, menuCursor.height / 2);
        Cursor.SetCursor(menuCursor, hotspot, CursorMode.Auto);
    }
   
}
