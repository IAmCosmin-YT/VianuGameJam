using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zana : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    Vector2 worldPos = Vector2.zero;
    Vector2 pos;
    Vector2 zana;

    [SerializeField] Vector2[] waypoints;

    int nr = 0;
    float smoothness = .01f;

    bool active = false;
    bool stopAllPlayerInput = false;


    private void Awake()
    {
        zana = gameObject.transform.position;
        pos = zana;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !active && !stopAllPlayerInput)
        {
            active = true;
            stopAllPlayerInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && active)
        {
            active = false;
            for(int i = 1; i<nr; i++)
            {
                while(zana != pos)
                {
                    pos.x = Mathf.Lerp(waypoints[i - 1].x, waypoints[i].x, smoothness);
                    pos.y = Mathf.Lerp(waypoints[i - 1].y, waypoints[i].y, smoothness);
                    gameObject.transform.position = pos;
                }
            }
            for(int i = 0; i < nr; i++)
            {
                waypoints[i] = Vector2.zero;
            }
            nr = 0;
            stopAllPlayerInput = false;
        }

        if (active)
            RememberFuturePos();


        if (Input.GetKeyDown(KeyCode.Mouse0) && !stopAllPlayerInput)
        {
            mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        }
        pos.x = Mathf.Lerp(gameObject.transform.position.x, worldPos.x, smoothness);
        pos.y = Mathf.Lerp(gameObject.transform.position.y, worldPos.y, smoothness);
        gameObject.transform.position = pos;

    }

    void RememberFuturePos()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            waypoints[nr] = worldPos;
            nr++;
        }
    }
}
