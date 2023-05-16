using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 mousePos;
    private int targetIndex = 0, posIndex = 0;
    [SerializeField] Vector2[] posQueue = null;
    [SerializeField] float speed = 0.1f;
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(posIndex != posQueue.Length){
                posQueue[posIndex++] = mousePos;
            }
        }
        if(posQueue[targetIndex] != Vector2.zero){
            MovePlayer(posQueue[targetIndex]);
            if(transform.position.x == posQueue[targetIndex].x && transform.position.y == posQueue[targetIndex].y) targetIndex++;
            if(targetIndex == posQueue.Length){
                targetIndex = 0;
                posIndex = 0;
                posQueue = null;
            }
        }

    }

    void MovePlayer(Vector2 target){
        Vector2 pos = transform.position;
        pos = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
        transform.position = pos;

    }
}
