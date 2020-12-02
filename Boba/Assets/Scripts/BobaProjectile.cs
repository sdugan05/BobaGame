using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaProjectile : MonoBehaviour {
    // Speed of projectile
    public float speed;
    public bool goesUp;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (goesUp) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // If boba collides destroy boba
        Destroy(gameObject);
        
        // Check if boba collided with a button
        if (other.gameObject.CompareTag("Button")) {
            // Tell the button that it has been hit
            other.gameObject.GetComponent<StartButton>().OnHit();
        }
    }
}
