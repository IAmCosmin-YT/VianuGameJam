using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 mousePos;
    private int targetIndex = 0, posIndex = 0;
    private bool canMove, singleClick, facingRight;
    public Vector2[] posQueue = null;
    [SerializeField] float speed = 5f;
    [SerializeField] ParticleSystem particle;
    public Text text;
    private Animator anim;

    private void Start() {
        text.text = null;
        anim = GetComponent<Animator>();
        anim.Play("Zana");
    }
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos.x < transform.position.x && facingRight == true){
                FlipCharacter();
                facingRight = false;
            }
            else if(mousePos.x > transform.position.x && facingRight == false){
                FlipCharacter();
                facingRight = true;
            }
            if(Input.GetKey(KeyCode.LeftShift) == false){
                singleClick = true;
            }
            else{
                singleClick = false;
                if(posIndex != posQueue.Length){
                    canMove = true;
                    posQueue[posIndex++] = mousePos;
                    text.text = "Move Queue: x" + posIndex.ToString();
                }
            }
            Instantiate(particle, mousePos,Quaternion.identity);
        }
        //if(Input.GetKeyDown(KeyCode.Mouse1)){
         //   canMove = false;    
          //  ResetQueue();
        //}
        if(posQueue[targetIndex] != Vector2.zero && canMove == true){
            MovePlayer(posQueue[targetIndex]);
            if(transform.position.x == posQueue[targetIndex].x && transform.position.y == posQueue[targetIndex].y) targetIndex++;
            if(targetIndex == posQueue.Length){
                ResetQueue();
            }
        }
        if(singleClick){
            ResetQueue();
            MovePlayer(mousePos);
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
        text.text = null;
    }

    void FlipCharacter(){
        Vector2 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }
}
