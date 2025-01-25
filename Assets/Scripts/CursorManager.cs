using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    private Vector2 cursorHotSpot;
    [SerializeField] private Texture2D cursorTexture;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height) / 2;
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
