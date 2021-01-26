using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaProjectile : MonoBehaviour {
    // Speed of projectile
    public float speed;
    public bool goesUp;
    public GameObject gameManager;
    private GameManager gameManagerScript;
    
    // Start is called before the first frame update
    void Start() {
        // Find and assign game manager
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        // move the projectile
        if (goesUp) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // If boba collides destroy boba
        
        // Check if boba collided with a button
        if (other.gameObject.CompareTag("Button")) {
            // Tell the button that it has been hit
            other.gameObject.GetComponent<StartButton>().OnHit();
            
            Destroy(gameObject);
        }
        else {
            if (other.gameObject.CompareTag("Player")) {
                // If a boba interacts with the player
                
                // Increase the player's boba count
                other.gameObject.GetComponent<PlayerController>().IncrementBobaCount(1);
                // Increase the score by 1
                gameManagerScript.score++;
                
                
                Destroy(gameObject);
            }
            else {
                if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerProjectile")) {
                    // Call enemy hit function
                    other.gameObject.GetComponent<EnemyController>().OnHit();
                    Destroy(gameObject);  
                }
            }

            if (!other.gameObject.CompareTag("Enemy")) {
                Destroy(gameObject);
            }
        } 
    }
}
