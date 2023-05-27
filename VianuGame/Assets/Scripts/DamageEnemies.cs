using UnityEngine;
using System.Collections.Generic;

public class DamageEnemies : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] WordManager wordManager;
    char endsWith;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null && !enemies.Contains(enemy))
            {
                enemies.Add(enemy);
            }
        }
        if (collision.CompareTag("Letter"))
        {
            string lastLetter = collision.name.ToString().Remove(0, collision.name.ToString().Length - 1);
            endsWith = lastLetter[0];
            Debug.Log(endsWith);
            wordManager.subtractSameLetters(endsWith);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null && enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
                while (enemy.speed <= enemy.speedCopy)
                {
                    enemy.speed += Time.deltaTime * 1.5f;
                }
            }
        }
    }

    private void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.TakeDamage();
            enemy.SlowDown();
        }
    }
}