using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 1;
    [SerializeField] public float speedCopy;
    [SerializeField] public float health = 1;
    [SerializeField] private soundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        speedCopy = speed;
    }

    private void Update()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
        transform.position = pos;
        if (health <= 0)
        {
            soundManager.PlayDieAudio();
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        health -= Time.deltaTime * 2;
    }
    public void SlowDown()
    {
        if(speed >= speedCopy/2)
        {
            speed -= Time.deltaTime*3;
        }
    }
}