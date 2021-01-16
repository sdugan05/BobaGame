using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    public float speed;
    public GameObject gameManager;
    private GameManager gameManagerScript;
    
    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            ReachedGround();
        }
    }

    // Called when a player projectile hits the enemy

    public void OnHit() {
        Die();
    }

    // Kill the enemy
    
    private void Die() {
        Destroy(gameObject);
    }

    private void ReachedGround() {
        gameManagerScript.health--;
        Destroy(gameObject);
    }

}
