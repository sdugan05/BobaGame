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
    public PlayerGroundSensor groundSensor;
    public bool grounded;
    public float jumpForce = 50f;
    
    // Boba projectile prefab
    public GameObject bobaPrefab;
    
    // Spawn point for boba projectile
    public GameObject shootPoint;
    
    // The player animator
    private Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start() {
        // Locate the player's rigidbody component
        playerRb = GetComponent<Rigidbody2D>();
        // Locate player animator component
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // MOVEMENT
        
        // Update the horizontalInput var with the input value of the horizontal axis
        horizontalInput = Input.GetAxis("Horizontal");
        
        // Check if player is touching the ground
        grounded = groundSensor.GetGrounded();
        
        // Check if player should jump and if player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);    
        }
        // Move player
        if (Mathf.Abs(horizontalInput) > Mathf.Epsilon) {
            playerRb.velocity = new Vector2(horizontalInput * playerMoveSpeed, playerRb.velocity.y); 
        }
        
        // Flip the player depending on the direction it is moving
        OrientPlayer();
        
        
        // SHOOTING
        if (Input.GetMouseButtonDown(0)) {
            // Start shoot animation
            // ShootBoba() is called inside the animation
            playerAnimator.SetTrigger("Attack");
        }
    }
    
    private void OrientPlayer() {
        // Orient the player
        if (horizontalInput > 0) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1.0f); 
        } else if (horizontalInput < 0) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1.0f);
        }
    }

    private void ShootBoba() {
        shootPoint.GetComponent<ParticleSystem>().Play();
        Debug.Log("Shot Boba!");
        Instantiate(bobaPrefab, shootPoint.transform.position, bobaPrefab.transform.rotation);
    }
}
