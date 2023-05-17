using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] public float health = 1;
    [SerializeField] private soundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
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
}