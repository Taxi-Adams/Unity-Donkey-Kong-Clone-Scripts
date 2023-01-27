using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieJumpSetup : MonoBehaviour
{
    public Animator baddieJumps;
    private float jumpHeight = 7.5f;
    private float heightGained = 0.0f;
    private float eventTimeIncrement = 2.5f;
    private float timeElapsed = 0.0f;
    private int multiple = 1;
    private bool canMoveUp = false;
    private bool canAnimate = true;

    void Start() {
        baddieJumps.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        // Checks if it has been 2.5 seconds and the baddie can jump again, but only while there are still beams to jump to
        if(timeElapsed >= 2.0f * multiple && timeElapsed <= 12.5f) {

            baddieJumps.SetBool("CanJump", true);
            canAnimate = false;
        }
        if(timeElapsed >= eventTimeIncrement * multiple && timeElapsed <= 15.0f) {
            multiple++;
            canMoveUp = true;
            // baddieJumps.SetBool("CanJump", true);
        }
        if(heightGained <= jumpHeight && canMoveUp) {
            gameObject.transform.position += Vector3.up * Time.deltaTime * 4.4f;
            heightGained += Time.deltaTime * 4.4f;
            if(heightGained >= 3.0f * jumpHeight / 4.0f) {
                baddieJumps.SetBool("CanJump", false);
                canAnimate = true;
            }
        } else {
            heightGained = 0.0f;
            canMoveUp = false;
        }

    }
}
