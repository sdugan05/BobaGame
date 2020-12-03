using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaFill : MonoBehaviour {
    private int currentKeyFrame = 0;

    public Animator bobaAnimator;

    public int boba;
    // Start is called before the first frame update
    void Start() {
        bobaAnimator.SetBool("Default", true);
    }

    // Update is called once per frame
    void Update() {
        bobaAnimator.SetInteger("Boba", boba);
    }

    public void AddBoba(int toAdd) {
        boba += toAdd;
        bobaAnimator.SetInteger("Boba", boba);
    }
}
