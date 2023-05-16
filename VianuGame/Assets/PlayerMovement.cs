using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 mousePos;
    private int targetIndex = 0, posIndex = 0;
    private bool canMove;
    [SerializeField] Vector2[] posQueue = null;
    [SerializeField] float speed = 0.1f;
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            canMove = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(posIndex != posQueue.Length){
                posQueue[posIndex++] = mousePos;
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            canMove = false;    
            ResetQueue();
        }
        if(posQueue[targetIndex] != Vector2.zero && canMove == true){
            MovePlayer(posQueue[targetIndex]);
            if(transform.position.x == posQueue[targetIndex].x && transform.position.y == posQueue[targetIndex].y) targetIndex++;
            if(targetIndex == posQueue.Length){
                ResetQueue();
            }
        }

    }

    void MovePlayer(Vector2 target){
        Vector2 pos = transform.position;
        pos = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
        transform.position = pos;
    }
    void ResetQueue(){
        targetIndex = 0;
        posIndex = 0;
        for(int i = 0; i<posQueue.Length; i++) posQueue[i] = Vector2.zero;
    }
}
