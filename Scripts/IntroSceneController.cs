using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroSceneController : MonoBehaviour
{
    public GameObject badGuyStarted;
    public GameObject beamStarted1;
    public GameObject beamStarted2;
    public GameObject beamStarted3;
    public GameObject beamStarted4;
    public GameObject beamStarted5;
    public GameObject beamStarted6;
    BaddieJumpSetup script1;
    BeamTilter script2;
    BeamTilter script3;
    BeamTilter script4;
    BeamTilter script5;
    BeamTilter script6;
    BeamTilter script7;



    private float timeElapsed = 0.0f;
    public Text startText;
    public Text titleText;
    private bool isGameStarted;
    private int countDown = 3;
    private float countDownTime = 0.0f;
    private float getReadyTime = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        script1 = badGuyStarted.GetComponent<BaddieJumpSetup>();
        script2 = beamStarted1.GetComponent<BeamTilter>();
        script3 = beamStarted2.GetComponent<BeamTilter>();
        script4 = beamStarted3.GetComponent<BeamTilter>();
        script5 = beamStarted4.GetComponent<BeamTilter>(); 
        script6 = beamStarted5.GetComponent<BeamTilter>();
        script7 = beamStarted6.GetComponent<BeamTilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted) {
            if(Input.GetMouseButtonDown(0)) {
                script1.enabled = true;
                Debug.Log("Badguy Started");
                script2.enabled = true;
                Debug.Log("Beam1 Started");
                script3.enabled = true;
                Debug.Log("Beam2 Started");
                script4.enabled = true;
                Debug.Log("Beam3 Started");
                script5.enabled = true;
                Debug.Log("Beam4 Started");
                script6.enabled = true;
                Debug.Log("Beam5 Started");
                script7.enabled = true;
                Debug.Log("Beam6 Started");
                isGameStarted = true;
                titleText.enabled = false;
                startText.enabled = false;
            }
        }
        if(isGameStarted) {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= getReadyTime) {
                startText.text = countDown.ToString();
                startText.enabled = true;
                getReadyTime += 1.0f;
                countDown--;
                if(timeElapsed > 18.0f) {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
