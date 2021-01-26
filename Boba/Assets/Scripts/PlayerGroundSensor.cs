using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundSensor : MonoBehaviour {
    // A simple class to check if the player is touching the ground
    private bool grounded;
    public Transform parentTransform;
    private int inColliders = 0;

    private void Update() {
        transform.position = parentTransform.position;
        if (inColliders > 0) {
            grounded = true;
        }
        else {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        inColliders++;
    }

    private void OnTriggerExit2D(Collider2D other) {
        inColliders--;
    }

    public bool GetGrounded() {
        return grounded;
    }
}
