using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text scoreText;
    public Text bonusText;
    public GameObject gameOverText;
    public GameObject gameWonText;
    public bool gameOver = false;
    private int score = 0;
    private int bonusScore = 5000;
    private float bonusCountdown = 3.0f;
    public bool gameWon = false;


    void Awake() {
        if(instance == null) {
            instance = this;
        }   else if(instance != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver) {
            bonusCountdown -= Time.deltaTime;
            if(bonusCountdown <= 0.0f) {
                bonusCountdown = 2.0f;
                bonusScore -= 100;
                bonusText.text = bonusScore.ToString();
            }
            if(bonusScore <= 0) {
                gameOver = true;
                gameOverText.SetActive(true);
            }
        }
        if(gameOver == true && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void playerScored() {
        if(gameOver) {
            return;
        } else {
            score += 100;
            scoreText.text = score.ToString("D6");
        }
    }

    public void playerDied() {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void playerWon() {
        if(!gameOver) {
            score += bonusScore;
            scoreText.text = score.ToString("D6");
            gameWonText.SetActive(true);
            gameWon = true;
            gameOver = true;
        }
    }
}
