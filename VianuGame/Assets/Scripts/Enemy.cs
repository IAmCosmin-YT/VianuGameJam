using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    public float speedCopy;
    public float health = 1;
    private AudioSource enemyKill;

    [SerializeField] Magician magician;

    private Animator animator;
    public ParticleSystem particle;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyKill = GameObject.Find("KillSlime").GetComponent<AudioSource>();
        magician = GameObject.FindGameObjectWithTag("Magician").GetComponent<Magician>();
        speedCopy = speed;
        animator.Play("Valva");
    }

    private void Update()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
        transform.position = pos;
        if (health <= 0)
        {
            magician.enemiesKilled++;
            //soundManager.PlayDieAudio();
            enemyKill.pitch = Random.Range(0.8f, 1.2f);
            enemyKill.Play();
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
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