using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // Boba prefab
    public GameObject bobaPrefab;
    
    // Enemy prefab

    public GameObject enemyPrefab;
    
    // Bool for whether or not to spawn boba
    public bool spawningEnabled;
    
    // Spawn range for boba
    private float spawnRangeX = 4.5f;
    private float spawnPosY = 4.5f;

    // How often to spawn boba (seconds)
    public float bobaSpawnRate = 0.5f;
    private float bobaSpawnTimer;

    public GameObject[] enemies;
    
    // time to wait before spawning enemies after boba pickups start
    public float enemySpawnRate = 10f;
    private float enemySpawnTimer;
    private float enemySpawnRateMin = 1.2f;
    private float enemySpawnRateMax = 2.5f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if (spawningEnabled) {
            // Enemy spawning
            enemySpawnTimer += Time.deltaTime;
            if (enemySpawnTimer >= enemySpawnRate) {
                // actual spawn rate
                enemySpawnRate = Random.Range(enemySpawnRateMin, enemySpawnRateMax);
                enemySpawnTimer = 0f;
                SpawnEnemy();
            }

            bobaSpawnTimer += Time.deltaTime;
            if (bobaSpawnTimer >= bobaSpawnRate) {
                bobaSpawnTimer = 0;
                SpawnBoba();
            }
        }
    }

    // Setter for prefab spawning
    
    public void SetSpawningEnabled(bool enabled) {
        spawningEnabled = enabled;
    }

    // Generate a random spawn position at the height specified in spawnRangeX
    
    private Vector3 GenerateRandomSpawnPos() {
        Vector3 spawnPos;
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        spawnPos = new Vector2(spawnX, spawnPosY);
        return spawnPos;
    }
    
    // Enemy spawning
    private void SpawnEnemy() {
        if (spawningEnabled) {
            Instantiate(enemyPrefab, GenerateRandomSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    
    // Boba pickup spawning
    private void SpawnBoba() {
        if (spawningEnabled) {
            Instantiate(bobaPrefab, GenerateRandomSpawnPos(), bobaPrefab.transform.rotation);
        }
    }
   
    // Public function to stop boba from spawning
    public void StopBobaSpawning() {
        SetSpawningEnabled(false);
    }
}
