﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaProjectile : MonoBehaviour {
    // Speed of projectile
    public float speed;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Ded");
        Destroy(gameObject);
    }
}
