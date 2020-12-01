using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundSensor : MonoBehaviour {
    // A simple class to check if the player is touching the ground
    private bool grounded;

    private void OnTriggerEnter2D(Collider2D other) {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        grounded = false;
    }

    public bool GetGrounded() {
        return grounded;
    }
}
