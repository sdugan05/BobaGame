using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Vars for movement
    // Var to store keyboard input values
    public float horizontalInput;

    // The player's rigidbody for adding forces to
    private Rigidbody2D playerRb;
    
    // Player movement speed multiplier
    public float playerMoveSpeed = 5f;
    
    // Bool to see if player should jump
    public float jumpForce = 50f;
    
    // Start is called before the first frame update
    void Start() {
        // Locate the player's rigidbody component
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // Update the horizontalInput var with the input value of the horizontal axis
        horizontalInput = Input.GetAxis("Horizontal");
        
        // Check if player should jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);    
        }
        // Move player
        if (Mathf.Abs(horizontalInput) > Mathf.Epsilon) {
            playerRb.velocity = new Vector2(horizontalInput * playerMoveSpeed, playerRb.velocity.y); 
        }
    }
}
