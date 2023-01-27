using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTilter : MonoBehaviour
{
    private float timeElapsed = 0.0f;
    private int caseNumb = 0;
    private int multiplier = 1;
    private bool rotated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates each beam when the baddie jumps on them (every 2.5 seconds) by 4.5 degrees
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 2.5f * multiplier) {
            multiplier++;
            caseNumb++;
            rotated = false;
        }
        switch(caseNumb) {
            case 1:
                if(gameObject.name == "Base" && !rotated) {
                    gameObject.transform.Rotate(0, 0, 4.5f);
                    rotated = true;
                }
                break;
            case 2:
                if(gameObject.name == "Row2" && !rotated) {
                    gameObject.transform.Rotate(0, 0, -4.5f);
                    rotated = true;
                }
                break;
            case 3:
                if(gameObject.name == "Row3" && !rotated) {
                    gameObject.transform.Rotate(0, 0, 4.5f);
                    rotated = true;
                }
                break;
            case 4: 
                if(gameObject.name == "Row4" && !rotated) {
                    gameObject.transform.Rotate(0, 0, -4.5f);
                    rotated = true;
                }
                break;
            case 5:
                if(gameObject.name == "Row5" && !rotated) {
                    gameObject.transform.Rotate(0, 0, 4.5f);
                    rotated = true;
                }
                break;
            case 6: 
                if(gameObject.name == "TopSlanted" && !rotated) {
                    gameObject.transform.Rotate(0, 0, -4.5f);
                    gameObject.transform.position += new Vector3(-0.2f, -0.75f, 0);
                    rotated = true;
                }
                break;
        }
    }
}
