using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionAbility : MonoBehaviour
{
    private Vector2 mousePos;
    [SerializeField]private Transform aimSpritePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimSpritePos.position = mousePos;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("click");
        }

    }
}
