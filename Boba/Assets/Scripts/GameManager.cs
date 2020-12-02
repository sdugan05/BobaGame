using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // The player
    public GameObject player;
    // The player controller
    private PlayerController playerController;
    
    // The spawn manager and spawn manager script
    public GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    
    // Start is called before the first frame update
    void Start() {
        // Locate player controller script
        playerController = player.GetComponent<PlayerController>();
        // Locate spawn manager script
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    // Called when the start button is hit
    public void OnStartButton() {
        // Set the player cup to empty
        playerController.SetAnimState(1);
        
        spawnManagerScript.SetSpawningEnabled(true);
        spawnManagerScript.StopBobaSpawning(10);
    }
}
