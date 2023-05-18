using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Magician : MonoBehaviour
{
    [SerializeField] public float health = 5;
    [SerializeField] private Animator cameraShake;
    [SerializeField] private AudioSource thunder;
    [SerializeField] private float x;
    [SerializeField] private Image healthbar;

    [SerializeField] private Animator bgA;
    [SerializeField] private Animator menuA;
    [SerializeField] private GameObject manager;
    [SerializeField] private GameObject zana;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private flowerReviver flower;
    [SerializeField] private GameObject[] enemies;


    public int enemiesKilled = 0;

    private void Start()
    {
        x = health;
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
            StartCoroutine(disableShake());
            cameraShake.SetBool("cameraShake", true);
            health--;
            Destroy(other.gameObject);
        }

        if (health <= 0)
        {
            flower.enabled = false;
            manager.SetActive(false);
            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            zana.SetActive(false);
            endMenu.SetActive(true);
            bgA.SetBool("menuOpen", true);
            menuA.SetBool("menuOpen", true);
        }
    }

    private IEnumerator disableShake()
    {
        if (!cameraShake.GetBool("cameraShake"))
        {
            cameraShake.SetBool("cameraShake", true);
            thunder.Play();
            yield return new WaitForSeconds(.3f);
            cameraShake.SetBool("cameraShake", false);
        }
    }
    public void Heal()
    {
        if(health < x)
        {
            health += .25f;
        }
    }
}