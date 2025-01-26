using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    private Vector2 cursorHotSpot;
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D hasTargetCursorTexture;

    Ray mouseRay;
    RaycastHit mouseHit;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height) / 2;

    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (mouseHit.collider.CompareTag("EnemyEntity") || mouseHit.collider.CompareTag("Button"))
        {
            Cursor.SetCursor(hasTargetCursorTexture, cursorHotSpot, CursorMode.Auto);
        }

        else 
        {
            Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
        }
    }
}
