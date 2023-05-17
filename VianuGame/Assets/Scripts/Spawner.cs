using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 screenBounds;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject enemyPrefab;

    private void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }
    private void SpawnEnemy(){
        GameObject inst = Instantiate(enemyPrefab) as GameObject;
        int spawnPoint = Random.Range(0,4);
        switch(spawnPoint){
            case 0: inst.transform.position = new Vector2(screenBounds.x + 1, Random.Range(-screenBounds.y, screenBounds.y)); break;
            case 1: inst.transform.position = new Vector2(-screenBounds.x - 1, Random.Range(-screenBounds.y, screenBounds.y)); break;
            case 2: inst.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + 1); break;
            case 3: inst.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - 1); break;
        }
    }

    IEnumerator enemyWave(){
        while(true){
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }
}
