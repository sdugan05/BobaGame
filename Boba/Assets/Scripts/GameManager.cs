using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int health;
    public int score = 0;

    public int maxHealth = 10;
    
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

    public GameObject scoreText;

    // Start is called before the first frame update
    void Start() {
        
        // Locate player controller script
        playerController = player.GetComponent<PlayerController>();
        // Locate spawn manager script
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        // Locate boba fill script
        bobaFill = bobaFillObj.GetComponent<BobaFill>();

        health = maxHealth;

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
        // Set the UI score text
        scoreText.GetComponent<Text>().text = score.ToString();

    }
    
    // Called when the start button is hit
    public void OnStartButton() {
        
        
        // Reset vars
        gameOverText.SetActive(false);
        score = 0;
        health = maxHealth;
         // Set the player cup to empty
        bobaFill.bobaAnimator.SetBool("Default", false);
        playerController.SetAnimState(1);
        // Set playercontroller gamestarted to true
        playerController.gameStarted = true;
        spawnManagerScript.enemySpawnRate = 10f;
        spawnManagerScript.SetSpawningEnabled(true);
       
    }

    private void GameOver() {
        // Stop spawning things, show a game over text, give player infinite ammo, set animation state to default from the start of the game
        spawnManagerScript.StopBobaSpawning();
        gameOverText.SetActive(true);
        playerController.gameStarted = false;
        bobaFill.bobaAnimator.SetBool("Default", true);
        playerController.SetAnimState(0);
        startButton.SetActive(true);
    }
}
