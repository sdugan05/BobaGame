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
    
    // Script for the boba
    public GameObject bobaFillObj;
    private BobaFill bobaFill;
    
    // Start is called before the first frame update
    void Start() {
        // Locate player controller script
        playerController = player.GetComponent<PlayerController>();
        // Locate spawn manager script
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        // Locate boba fill script
        bobaFill = bobaFillObj.GetComponent<BobaFill>();
        
    }

    // Update is called once per frame
    void Update() {
        bobaFill.boba = playerController.GetBobaCount();
    }
    
    // Called when the start button is hit
    public void OnStartButton() {
        // Set the player cup to empty
        bobaFill.bobaAnimator.SetBool("Default", false);
        playerController.SetAnimState(1);
        // Set playercontroller gamestarted to true
        playerController.gameStarted = true;
        
        spawnManagerScript.SetSpawningEnabled(true);
        spawnManagerScript.StopBobaSpawning(10);
    }
}
