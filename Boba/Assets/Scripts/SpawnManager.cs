using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // Boba prefab
    public GameObject bobaPrefab;
    // Bool for whether or not to spawn boba
    private bool spawningEnabled;
    
    // Spawn range for boba
    private float spawnRangeX = 4.5f;
    private float spawnPosY = 4.5f;

    // How often to spawn boba (seconds)
    public float bobaSpawnRate = 1f;
    
    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnBoba", 1, bobaSpawnRate);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetSpawningEnabled(bool enabled) {
        spawningEnabled = enabled;
    }

    private Vector3 GenerateRandomSpawnPos() {
        Vector3 spawnPos;
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        spawnPos = new Vector2(spawnX, spawnPosY);
        return spawnPos;
    }

    private void SpawnBoba() {
        if (spawningEnabled) {
            Instantiate(bobaPrefab, GenerateRandomSpawnPos(), bobaPrefab.transform.rotation);
        }
    }
    
    // Public function to stop boba from spawning after a certain amount of seconds has passed
    public void StopBobaSpawning(int secondsToWait) {
        StartCoroutine(StopBoba(secondsToWait));
    }

    private IEnumerator StopBoba(int secondsToWait) {
        yield return new WaitForSeconds(secondsToWait);
        SetSpawningEnabled(false);
    }
}
