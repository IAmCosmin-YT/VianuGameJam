using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zana : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    Vector2 worldPos = Vector2.zero;
    Vector2 pos;
    Vector2 zana;
    float smoothness = .01f;
    bool active = false;


    private void Awake()
    {
        zana = gameObject.transform.position;
        pos = zana;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            active = true;
        }
        pos.x = Mathf.Lerp(gameObject.transform.position.x, worldPos.x, smoothness);
        pos.y = Mathf.Lerp(gameObject.transform.position.y, worldPos.y, smoothness);
        gameObject.transform.position = pos;

    }
}
