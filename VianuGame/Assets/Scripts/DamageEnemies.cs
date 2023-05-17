using UnityEngine;
using System.Collections.Generic;

public class DamageEnemies : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();

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
                    enemy.speed += Time.deltaTime*1.5f;
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