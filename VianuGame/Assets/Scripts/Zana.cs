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
    int n = 0;
    float smoothness = .01f;

    bool active = false;
    bool activeGoToWp = false;
    bool stopAllPlayerInput = false;


    private void Awake()
    {
        zana = gameObject.transform.position;
        pos = zana;
    }

    // Update is called once per frame
    void Update()
    {
        GoToWaypoints();

        gameObject.transform.position = zana;
        if (Input.GetKeyDown(KeyCode.Mouse1) && !active && !stopAllPlayerInput)
        {
            active = true;
            stopAllPlayerInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && active)
        {
            active = false;
            activeGoToWp = true;
        }else if (nr == 5)
        {
            activeGoToWp = true;
        }

        if (active)
            RememberFuturePos();


        if (Input.GetKeyDown(KeyCode.Mouse0) && !stopAllPlayerInput)
        {
            mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        }
        if (!stopAllPlayerInput)
        {
            pos.x = Mathf.Lerp(zana.x, worldPos.x, smoothness);
            pos.y = Mathf.Lerp(zana.y, worldPos.y, smoothness);
            zana = pos;
        }
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
        if (nr == 5)
        {
            active = false;
        }
    }

    void GoToWaypoints()
    {
        if (activeGoToWp)
        {
            if (zana != waypoints[n])
            {
                pos.x = Mathf.Lerp(zana.x, waypoints[n].x, smoothness);
                pos.y = Mathf.Lerp(zana.y, waypoints[n].y, smoothness);
                zana = pos;
            }
        }
    }
}
