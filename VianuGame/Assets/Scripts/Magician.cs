using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Magician : MonoBehaviour
{
    [SerializeField] public float health = 5;
    [SerializeField] private Animator cameraShake;
    [SerializeField] private float x;
    [SerializeField] private Image healthbar;
    public int enemiesKilled = 0;

    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject godot;
    [SerializeField] GameObject manager;
    [SerializeField] Animator bgA;
    [SerializeField] Animator menu;

    private void Start()
    {
        x = health;
    }

    private void Update()
    {
        if (healthbar.fillAmount * x > health)
        {
            healthbar.fillAmount -= Time.deltaTime * 2;
        }
        if (healthbar.fillAmount * x < health)
        {
            healthbar.fillAmount += Time.deltaTime * 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //StartCoroutine(disableShake());
            cameraShake.SetBool("cameraShake", true);
            health--;
            Destroy(other.gameObject);
        }

        if (healthbar.fillAmount == 0)
        {
            manager.SetActive(false);
            godot.SetActive(false);
            endScreen.SetActive(true);
            bgA.speed = 1;
            menu.speed = 1;
            bgA.SetBool("menuOpen", true);
            menu.SetBool("menuOpen", true);
        }
    }
    /*
    private IEnumerator disableShake()
    {
        if (!cameraShake.GetBool("cameraShake"))
        {
            cameraShake.SetBool("cameraShake", true);
            yield return new WaitForSeconds(.3f);
            cameraShake.SetBool("cameraShake", false);
        }
<<<<<<< HEAD
    }
    public void Heal()
    {
        if(health<x)
        health += .25f;
    }
=======
    }*/
>>>>>>> 19a5b185a4d33ec07b56ef0ee6daa1751ab67042
}