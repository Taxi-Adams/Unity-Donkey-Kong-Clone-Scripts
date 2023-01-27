using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieAnims : MonoBehaviour
{
    public Animator badGuyAnim;
    private float timeElapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        badGuyAnim.gameObject.GetComponent<Animator>();
        badGuyAnim.SetBool("Lost", false);
    }

    // Update is called once per frame
    void Update() {
        if(!GameControl.instance.gameWon) {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= 10.0f) {
                timeElapsed = 0.0f;
                badGuyAnim.SetBool("Throwing", false);
            } else if(timeElapsed >= 6.25f) {
                badGuyAnim.SetBool("Throwing", true);
            }
        } else {
            badGuyAnim.SetBool("Lost", true);
        }  
    }
}
