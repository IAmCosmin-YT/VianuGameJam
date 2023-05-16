using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Magician : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            health -= 1;
        }
        if(health == 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
