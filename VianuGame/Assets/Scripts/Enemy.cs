using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    public float speedCopy;
    public float health = 1;
    private soundManager soundManager;
<<<<<<< HEAD
    [SerializeField] Magician magician;
=======
    [SerializeField] public AudioClip sound;
>>>>>>> 19a5b185a4d33ec07b56ef0ee6daa1751ab67042

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        magician = GameObject.FindGameObjectWithTag("Magician").GetComponent<Magician>();
        speedCopy = speed;
    }

    private void Update()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
        transform.position = pos;
        if (health <= 0)
        {
<<<<<<< HEAD
            magician.enemiesKilled++;
            soundManager.PlayDieAudio();
=======
            soundManager.source.pitch = Random.Range(0.8f, 1.2f);
            soundManager.PlaySound(sound);
>>>>>>> 19a5b185a4d33ec07b56ef0ee6daa1751ab67042
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