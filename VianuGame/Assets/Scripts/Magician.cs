using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Magician : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private Animator cameraShake;
    [SerializeField] private int x;
    [SerializeField] private Image healthbar;

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

        if (health == 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 0;
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
    }*/
}