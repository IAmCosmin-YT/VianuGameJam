using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    void Update()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, Vector2.zero, speed*Time.deltaTime);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if(other.CompareTag("Magician")){
            Destroy(gameObject);
        }
    }
}
