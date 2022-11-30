using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_script : MonoBehaviour
{
    public Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorOffset = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
