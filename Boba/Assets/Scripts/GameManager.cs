using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int health = 10;
    public int score = 0;

    public GameObject startButton;
    
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

    public GameObject healthBar;

    public bool gameOver;
    public GameObject gameOverText;

    private Scene mainScene;
    
    // Start is called before the first frame update
    void Start() {
        mainScene = SceneManager.GetActiveScene();
        
        // Locate player controller script
        playerController = player.GetComponent<PlayerController>();
        // Locate spawn manager script
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        // Locate boba fill script
        bobaFill = bobaFillObj.GetComponent<BobaFill>();

        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        bobaFill.boba = playerController.GetBobaCount();
        healthBar.GetComponent<HealthBar>().SetHealth(health);
        
        // Check if gameover

        if (health == 0) {
            GameOver();
        }
    }
    
    // Called when the start button is hit
    public void OnStartButton() {
         // Set the player cup to empty
        bobaFill.bobaAnimator.SetBool("Default", false);
        playerController.SetAnimState(1);
        // Set playercontroller gamestarted to true
        playerController.gameStarted = true;
        
        spawnManagerScript.SetSpawningEnabled(true);
       
    }

    private void GameOver() {
        spawnManagerScript.StopBobaSpawning(1);
        gameOverText.SetActive(true);
        playerController.gameStarted = false;
        bobaFill.bobaAnimator.SetBool("Default", true);
        playerController.SetAnimState(0);
    }
}
