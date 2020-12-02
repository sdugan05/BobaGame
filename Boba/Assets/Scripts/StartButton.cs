using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    // Game manager script
    public GameObject gameManager;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnHit() {
        // Start game through game manager
        gameManager.GetComponent<GameManager>().OnStartButton();
        // Destroy button
        gameObject.SetActive(false);
    }
}
