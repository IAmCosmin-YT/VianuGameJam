using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    public float speedCopy;
    public float health = 1;
    private soundManager soundManager;
    [SerializeField] public AudioClip sound;

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
            soundManager.source.pitch = Random.Range(0.8f, 1.2f);
            soundManager.PlaySound(sound);
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